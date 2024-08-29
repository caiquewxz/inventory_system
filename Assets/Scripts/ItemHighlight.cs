using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHighlight : MonoBehaviour
{
    [SerializeField] private Text descriptionText;

    private SlotItem highlightedItem;
    
    public void ShowItem(SlotItem item)
    {
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
}
