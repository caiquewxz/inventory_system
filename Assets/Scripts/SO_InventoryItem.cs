using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//enum que guarda os tipos que o item pode ser e o seta na variavel itemTipe da classe SO_InventoryItem.
public enum ItemType
{
    Potion,
    Weapon,
    Money
}
[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "ScriptableObjects/NewItem", order = 1)]
public class SO_InventoryItem : ScriptableObject
{
    //variáveis que o objeto usa para armazenar suas informações principais(nome, descrição, quantidade máxima que pode ser carregado, sprite, prefab coletável e tipo do objeto).
    public string name;
    public string description;
    public int maxQuantity;
    public bool stackable;
    public Sprite sprite;
    public GameObject collectablePrefab;
    public ItemType  itemType;
    
    [Tooltip("usado para lógica do item. Como por exemplo quanto sangue irá ser regenerado por uma poção")]
    public int Value;

}
