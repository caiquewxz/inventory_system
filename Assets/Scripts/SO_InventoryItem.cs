using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "ScriptableObjects/NewItem", order = 1)]
public class SO_InventoryItem : ScriptableObject
{
    public string name;
    public string description;
    public int maxQuantity;
    public bool stackable;
    public Texture2D sprite;
    public GameObject collectablePrefab;
}
