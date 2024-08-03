using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int quantity = 1;
    public SO_InventoryItem itemData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TryCollectItem();
        }
    }

    public void TryCollectItem()
    {
        Inventory.instance.CollectItem(this);
    }
}
