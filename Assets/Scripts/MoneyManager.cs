using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    public int playerMoney
    {
        get
        {
            return _playerMoney;
        }
        set
        {
            _playerMoney = value;
            SetPlayerMoneyText();
        }
    }

    private int _playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 0;
    }

    private void SetPlayerMoneyText()
    {
        if (moneyText)
        {
            moneyText.text = "Player's Money: " + playerMoney;
        }
    }
}
