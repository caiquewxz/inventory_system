using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    public List<SlotItem> shopSlots;
    [SerializeField] private Color colorToUncheckSlot;
    [SerializeField] private Color colorToHighlightSlot;
    [SerializeField] private ShopItemHighlight shopItemHighlight;
    [SerializeField] private GameObject shopGameObject;
    [SerializeField] private GameObject unsufficientMoneyPopup;

    private SlotItem selectedSlot;

    void Awake()
    {
        Close();
    }

    public void TryBuyItem(int index)
    {
        if (Inventory.Instance.SpendMoney(shopSlots[index].itemData.price))
        {
            Inventory.Instance.CollectItem(shopSlots[index]);
        }
        else
        {
            Instantiate(unsufficientMoneyPopup);
        }
    }

    public void Close()
    {
        shopItemHighlight.gameObject.SetActive(false);
        shopGameObject.SetActive(false);
    }

    public void Open()
    {
        shopGameObject.SetActive(true);
    }

    public void SelectItem(int index)
    {
        shopSlots[index].backgroundImage.color = colorToHighlightSlot;
        if (selectedSlot)
        {
            selectedSlot.backgroundImage.color = colorToUncheckSlot;
        }
        selectedSlot = shopSlots[index];
        shopItemHighlight.ShotItemDescription(shopSlots[index].itemData.description + " Custa " + shopSlots[index].itemData.price + " dinheiros.");
        shopItemHighlight.gameObject.SetActive(true);
    }
    
}
