using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance; // Singleton D

    public void Awake()
    {
        instance = this;
    }

    public int currentCoins;
    public CoinPickup coin;

    public void AddCoins(int coinsToAdd) // Add coins. D
    {
        currentCoins += coinsToAdd; // Add the coins. D
        UIController.instance.UpdateCoins(); // Update the coins. D
    }
    public void DropCoin(Vector3 position, int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(0.2f, 1f, 0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }
    public void SpendCoins(int coinsToSpend) // Spend coins. GK
    {
        currentCoins -= coinsToSpend; // Subtract the coins. GK
        UIController.instance.UpdateCoins(); // Update the coins. GK
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}