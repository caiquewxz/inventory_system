using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    
    public static Inventory Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<Inventory>();
            }

            return _instance;
        }
    }

    public List<SlotItem> slots = new();
    public GameObject inventoryObject;
    public bool isOpen;
    public ItemHighlight itemHighlightObject;
    public MoneyManager moneyManager;

    private void Awake()
    {
        if (Instance != this)
        {
            if (Instance.gameObject != gameObject)
                Destroy(gameObject);

            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            isOpen = false;
            Close();

        }

        if (!moneyManager)
        {
            moneyManager = FindObjectOfType<MoneyManager>();
        }
    }

    void Update()
    {
        //verifica se a tecla que abre o inventário é pressionada, se for ele inverte o valor de isOpen(variável que define se o inventário está aberto) e se o inventário ja estiver aberto, ele o fecha, e se estiver fechado, ele o abre.
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }

            isOpen = !isOpen;
        }
    }

    void Open()
    {
        inventoryObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Close()
    {
        itemHighlightObject.gameObject.SetActive(false);
        inventoryObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CollectItem(SlotItem item)
    {
        Collectable newCollectable = inventoryObject.AddComponent<Collectable>();
        newCollectable.quantity = item.quantity;
        newCollectable.itemData = item.itemData;
        newCollectable.collectablePrefab = item.collectablePrefab;
        
        CollectItem(newCollectable, true);
        
        Destroy(newCollectable);
    }
    public void CollectItem(Collectable collectable, bool isFromShop = false)
    {
        SlotItem availableSlot = GetFirstAvailableSlot(collectable);
        if (collectable.itemData.itemType == ItemType.Money)
        {
            moneyManager.playerMoney += collectable.quantity;
        }

        if (availableSlot)
        {
            //deixa o slot ocupado, pega o sprite, descrição e quantidade do objeto que o player está coletando.
            availableSlot.occupied = true;
            availableSlot.slotImage.sprite = collectable.itemData.sprite;
            availableSlot.itemData = collectable.itemData;
            availableSlot.collectablePrefab = Instantiate(collectable.collectablePrefab);
            availableSlot.collectablePrefab.SetActive(false);
            availableSlot.SetQuantity(collectable.quantity + availableSlot.quantity);

            //se for maior que a quantidade máxima por slot, ir para próximo slot.
            if (availableSlot.quantity > collectable.itemData.maxQuantity)
            {
                collectable.quantity = availableSlot.quantity - collectable.itemData.maxQuantity;
                availableSlot.SetQuantity(collectable.itemData.maxQuantity);
                CollectItem(collectable);
            }

            //se não for stackavel, esconde o texto de quantity
            if (!availableSlot.itemData.stackable)
            {
                availableSlot.quantityText.text = "";
            }

            if(!isFromShop)
                Destroy(collectable.transform.parent.gameObject);

            itemHighlightObject.UncheckItemImage();
        }
    }

    private SlotItem GetFirstAvailableSlot(Collectable collectable)
    {
        foreach (SlotItem slot in slots)
        {
            bool isSameItem = slot.itemData && collectable.itemData.name.Equals(slot.itemData.name);
            bool isStackable = collectable.itemData.stackable;
            bool hasSpaceAvailable = slot.quantity < collectable.itemData.maxQuantity;
            if (!slot.occupied || (isSameItem && isStackable && hasSpaceAvailable))
            {
                return slot;
            }
        }

        return null;
    }

    public bool SpendMoney(int amount)
    {
        if (moneyManager.playerMoney < amount) return false;
        moneyManager.playerMoney -= amount;
        int debt = -amount;
        foreach (SlotItem item in slots)
        {
            if (item.itemData.itemType == ItemType.Money)
            {
                debt += item.quantity;
                
                item.SetQuantity(debt > 0 ? debt : 0);

                if (debt >= 0)
                {
                    break;
                }
            }
        }

        return true;
    }
}
