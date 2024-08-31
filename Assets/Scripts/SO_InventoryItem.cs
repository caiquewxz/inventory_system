using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public enum ItemType
{
    Potion,
    Weapon,
    Money
}
[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "ScriptableObjects/NewItem", order = 1)]
public class SO_InventoryItem : ScriptableObject
{
    public string name;
    public string description;
    public int maxQuantity;
    public bool stackable;
    public Sprite sprite;
    public ItemType  itemType;
    public int price;
    
    [FormerlySerializedAs("Value")] [Tooltip("usado para lógica do item. Como por exemplo quanto sangue irá ser regenerado por uma poção")]
    public int value;

}
