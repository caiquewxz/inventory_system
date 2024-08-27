using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotRenderer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private SlotItem item;

    public void OnPointerDown(PointerEventData eventData)
    {
        item?.OnPointerDown(eventData);
    }
}
