using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Currency : MonoBehaviour
{
    //set initial currency
    private int numOfCoins;
    [SerializeField] private Text currency;

    // Start is called before the first frame update
    void Start()
    {
        numOfCoins = 0;
        SetCurrency();
    }

    public int getCoins() { 
        return numOfCoins;
    }

    public string getCurrency() {
        return currency.ToString();
    }

    //update UI
    private void SetCurrency() { 
        string currencyText = numOfCoins.ToString();
        currency.text = currencyText;
    }

   public void gainCoins(int amount) {
        numOfCoins += amount;
        SetCurrency();
    }

      public void loseCoins(int amount) {
        numOfCoins -= amount;
        SetCurrency();
    }


    //can set tests for currency increasing when enemy dies

    //test - when player buys something currency decreases.

    //when level loads the currency should be 0
}
