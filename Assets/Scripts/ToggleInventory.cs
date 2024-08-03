using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryObject;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
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
        inventoryObject.SetActive(true);
    }

    void Close()
    {
        inventoryObject.SetActive(false);
    }
}
