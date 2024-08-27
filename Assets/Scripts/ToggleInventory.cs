using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryObject;
    public static bool isOpen;
    private SlotItem[] allSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        allSlots = inventoryObject.GetComponentsInChildren<SlotItem>();
        Close();
    }

    // Update is called once per frame
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

    //método que abre o inventário
    void Open()
    {
        //muda o alpha de cada slot no canvas, deixando todos os slots e o cursor do mouse visíveis, e também destrava o movimento do cursor.
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
    //método que fecha o inventário.
    void Close()
    {
        //muda o alpha de cada slot no canvas, deixando todos os slots e o cursor do mouse invisíveis, e trava o cursor do mouse no centro da tela.
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
