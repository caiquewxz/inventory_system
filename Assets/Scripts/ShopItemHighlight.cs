using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemHighlight : MonoBehaviour
{
    [SerializeField] private Text descriptionText;

    public void ShotItemDescription(string description)
    {
        descriptionText.text = description;
    }
}
