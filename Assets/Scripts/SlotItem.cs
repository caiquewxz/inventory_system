using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IPointerDownHandler
{
    public bool occupied;
    public SO_InventoryItem itemData;
    public ItemType itemType;
    public Text quantityText;
    public int quantity;
    public Image slotImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DropItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            UseItem();
        }
    }

    void DropItem()
    {
        Debug.Log("Drop");
    }

    void UseItem()
    {
        Debug.Log("Use");
    }
}