using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    private static Inventory _instance;

    //singleton para acessar de qualquer lugar e haver apenas uma instância da classe Inventory.
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
        }
    }

    //método de coletar item.
    public void CollectItem(Collectable collectable)
    {
        SlotItem availableSlot = GetFirstAvailableSlot(collectable);
        if (availableSlot)
        {
            //deixa o slot ocupado, pega o sprite, descrição e quantidade do objeto que o player está coletando.
            availableSlot.occupied = true;
            availableSlot.slotImage.sprite = collectable.itemData.sprite;
            availableSlot.itemData = collectable.itemData;
            availableSlot.SetQuantity(collectable.quantity + availableSlot.quantity);

            //se for maior que a quantidade máxima por slot, ir para próximo slot.
            if (availableSlot.quantity > collectable.itemData.maxQuantity)
            {
                collectable.quantity = availableSlot.quantity - collectable.itemData.maxQuantity;
                availableSlot.SetQuantity(collectable.itemData.maxQuantity);
                CollectItem(collectable);
            }

            //vse não for stackavel, esconde o texto de quantity
            if (!availableSlot.itemData.stackable)
            {
                availableSlot.quantityText.text = "";
            }
            
            Destroy(collectable.transform.parent.gameObject);
        }
    }

    private SlotItem GetFirstAvailableSlot(Collectable collectable)
    {
        foreach(SlotItem slot in slots)
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
}
