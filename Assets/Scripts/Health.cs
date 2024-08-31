using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerHP
    {
        get => _playerHp;
        
        set
        {
            _playerHp = value;
            if (_playerHp > maxHp)
            {
                _playerHp = maxHp;
            }
            if (playerHpText)
            {
                playerHpText.text = "Player's HP: " + _playerHp;
            }
            
        }
    }
    [SerializeField] private int _playerHp = 50;
    
    [SerializeField] private int maxHp = 100;
    [SerializeField] private Text playerHpText;
    
    public static Health Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<Health>();
            }

            return _instance;
        }
    }

    private static Health _instance;
    
    private void Awake()
    {
        if (Instance != this)
        {
            if (Instance.gameObject != gameObject)
                Destroy(gameObject);

            Destroy(this);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        playerHP = _playerHp;
    }
    
}
