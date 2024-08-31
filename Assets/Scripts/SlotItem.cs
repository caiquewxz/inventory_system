using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public bool occupied;
    public SO_InventoryItem itemData;
    public Text quantityText;
    public int quantity;
    public Image slotImage;
    public Image backgroundImage;
    public float dropForce = 100f;
    public bool isShopSlot;
    public int shopIndex;
    [SerializeField] private Shop shop;
    [SerializeField] public GameObject collectablePrefab;

    private Transform dropReference;
    private Health healthComponent;
    private MoneyManager moneyManager;
    void Start()
    {
        GameObject dropReferenceObject = GameObject.FindGameObjectWithTag("DropReference");
        if (dropReferenceObject)
        {
            dropReference = dropReferenceObject.transform;
        }

        moneyManager = FindObjectOfType<MoneyManager>();

    }

    //método que verifica se o player clica com o botão esquerdo ou direito nos slots. Se clicar com o botão direito, ele dropa o item, se ele clicar com o esquerdo, ele o usa.
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isShopSlot)
        {
            shop.SelectItem(shopIndex);
            return;
        }
        
        if (Inventory.Instance.itemHighlightObject)
        {
            Inventory.Instance.itemHighlightObject.ShowItem(this);
            Inventory.Instance.itemHighlightObject.gameObject.SetActive(true);
            Inventory.Instance.itemHighlightObject.HighlightItemImage();
        }
    }

    //método que define a quantidade do item empilhado, alterando a variável de quantidade, e a string que armazena a quantidade que o item carrega.
    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        quantityText.text = quantity == 0 ? "" : quantity.ToString();
        if (quantity <= 0)
        {
            occupied = false;
            slotImage.sprite = null;
            itemData = null;
            Inventory.Instance.itemHighlightObject.UncheckItemImage();
        }
    }
    
    //método que faz o item ser dropado.
    public void DropItem()
    {
        Debug.Log(Inventory.Instance.itemHighlightObject.gameObject.name);
        Inventory.Instance.itemHighlightObject.UncheckItemImage();

        if (itemData.itemType == ItemType.Money)
        {
            moneyManager.playerMoney -= quantity;
        }
        
        GameObject spawnedCollectable = Instantiate(collectablePrefab, dropReference.position, dropReference.rotation);
        spawnedCollectable.SetActive(true);
        //verifica se o item que foi dropado é um coletável.
        if (spawnedCollectable)
        {
            Collectable collectable = spawnedCollectable.GetComponentInChildren<Collectable>();
            collectable.quantity = quantity;

            Rigidbody rb = spawnedCollectable.GetComponent<Rigidbody>();
            
            //depois de pegar o rigidbody do objeto dropado, ele coloca uma força de impulso, o jogando para frente.
            if (rb)
            {
                Vector3 initialForce = PlayerMovement.instance.transform.forward * dropForce;
                rb.AddForce(initialForce, ForceMode.Impulse);
            }
            
            //ele define a quantidade do item no slot do inventario como zero, desocupa o slot, retira as informações do item, e remove o sprite do slot.
            SetQuantity(0);
            occupied = false;
            itemData = null;
            slotImage.sprite = null;
        }
        
    }

    public void UseItem()
    {
        if (itemData && itemData.itemType == ItemType.Potion)
        {
            Health.Instance.PlayerHP += itemData.value;
            SetQuantity(quantity - 1);
        }
    }
}