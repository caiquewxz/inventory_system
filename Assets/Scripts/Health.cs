using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int playerHp = 50;
    public int maxHp = 100;
    public Text playerHpText;
    
 void Update()
    {
        if (playerHpText)
        {
            playerHpText.text = "Player's HP: " + playerHp;
        }

        if (playerHp > maxHp)
        {
            playerHp = maxHp;
        }
    }
}
