using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int quantity = 1;
    public SO_InventoryItem itemData;
    
    //método que verifica se o objeto coletável está colidindo com o player, se estiver, ele usa o método TryCollectItem(método que tenta coletar um item através da instancia da classe Inventory, que é um singleton).
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TryCollectItem();
        }
    }

    //método que tenta coletar um item através da instancia da classe Inventory, que é um singleton
    public void TryCollectItem()
    {
        Inventory.instance.CollectItem(this);
    }
}
