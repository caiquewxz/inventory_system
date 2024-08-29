using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    [SerializeField] private Text openStoreText;
    [SerializeField] private GameObject storeObject;
    [SerializeField] private bool isStoreOpen;
    
    private void Start()
    {
        openStoreText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (openStoreText.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.B))
        {
            if (isStoreOpen)
            {
                CloseStore();
            }
            else
            {
                OpenStore();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (openStoreText && other.gameObject.CompareTag("Player"))
        {
            openStoreText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (openStoreText && other.gameObject.CompareTag("Player"))
        {
            openStoreText.gameObject.SetActive(false);
            CloseStore();
        }
    }

    void OpenStore()
    {
        storeObject?.gameObject.SetActive(true);
        isStoreOpen = true;
    }

    void CloseStore()
    {
        storeObject?.gameObject.SetActive(false);
        isStoreOpen = false;
    }
}
