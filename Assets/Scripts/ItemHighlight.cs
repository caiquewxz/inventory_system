using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemHighlight : MonoBehaviour
{
    [SerializeField] private Text descriptionText;
    [SerializeField] private Color colorToUncheckSlot;
    [SerializeField] private Color colorToHighlightSlot;
    public static SlotItem highlightedItem;
    private SlotItem previousItem;

    public void ShowItem(SlotItem item)
    {
        if (!item.occupied) return;
        UncheckItemImage();
        highlightedItem = item;
        descriptionText.text = item.itemData.description;
    }

    public void UseItem()
    {
        highlightedItem?.UseItem();
        if (highlightedItem.quantity <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DropItem()
    {
        highlightedItem?.DropItem();
        if (highlightedItem.quantity <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void HighlightItemImage()
    {
        if (highlightedItem)
        {
            highlightedItem.backgroundImage.color = colorToHighlightSlot;
        }
    }

    public void UncheckItemImage()
    {
        if (highlightedItem)
        {
            highlightedItem.backgroundImage.color = colorToUncheckSlot;
        }
    }
}
