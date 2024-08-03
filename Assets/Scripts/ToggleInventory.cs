using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryObject;
    public static bool isOpen;
    private CanvasRenderer[] allSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        allSlots = inventoryObject.GetComponentsInChildren<CanvasRenderer>();
        Close();
    }

    // Update is called once per frame
    void Update()
    {
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
        foreach (CanvasRenderer slot in allSlots)
        {
            slot.SetAlpha(1f);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Close()
    {
        foreach (CanvasRenderer slot in allSlots)
        {
            slot.SetAlpha(.0f);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
