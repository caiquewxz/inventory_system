using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public bool occupied;

    public SO_InventoryItem itemData;
    public ItemType itemType;
    public Text quantityText;
    public int quantity;
    public Image slotImage;
}
