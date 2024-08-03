using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    private static Inventory _instance;

    public static Inventory instance
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

    public void CollectItem(Collectable collectable)
    {
        SlotItem emptySlot = GetFirstEmptySlot();
        if (emptySlot)
        {
            emptySlot.occupied = true;
            emptySlot.slotImage.sprite = collectable.itemData.sprite;
            emptySlot.itemData = collectable.itemData;
            emptySlot.quantity = collectable.quantity;
            Destroy(collectable.gameObject);
        }
    }

    private SlotItem GetFirstEmptySlot()
    {
        foreach(SlotItem slot in slots)
        {
            if (!slot.occupied)
            {
                return slot;
            }
        }

        return null;
    }
}
