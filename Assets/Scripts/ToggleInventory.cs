using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryObject;
    public static bool isOpen;
    private SlotItem[] allSlots;
    
    void Start()
    {
        isOpen = false;
        allSlots = inventoryObject.GetComponentsInChildren<SlotItem>();
        Close();
    }

    void Update()
    {
        //verifica se a tecla que abre o inventário é pressionada, se for ele inverte o valor de isOpen(variável que define se o inventário está aberto) e se o inventário ja estiver aberto, ele o fecha, e se estiver fechado, ele o abre.
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }

            isOpen = !isOpen;
        }
    }

    void Open()
    {
        foreach (SlotItem slot in allSlots)
        {
            CanvasRenderer[] allRederers = slot.GetComponentsInChildren<CanvasRenderer>();
            foreach (CanvasRenderer renderer in allRederers)
            {
                renderer.SetAlpha(1f);
            }
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void Close()
    {
        foreach (SlotItem slot in allSlots)
        {
            CanvasRenderer[] allRederers = slot.GetComponentsInChildren<CanvasRenderer>();
            foreach (CanvasRenderer renderer in allRederers)
            {
                renderer.SetAlpha(.0f);
            }
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
