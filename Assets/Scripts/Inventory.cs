using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Weapon,
    Money
}

public class Inventory : MonoBehaviour
{
    public List<SlotItem> slots = new();
}
