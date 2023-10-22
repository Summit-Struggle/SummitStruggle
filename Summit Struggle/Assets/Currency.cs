using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Currency : MonoBehaviour
{
    //set initial currency
    private int currency;
    [SerializeField] private Text coins;

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
    }


    //update UI
    private void SetCurrency() { 
        string currencyText = currency.ToString();
        coins.text = currencyText;
    }

   private void gainCoins(int amount) {
        currency += amount;
        SetCurrency();
    }

      private void loseCoins(int amount) {
        currency -= amount;
        SetCurrency();
    }


    //can set tests for currency increasing when enemy dies

    //test - when player buys something currency decreases.

    //when level loads the currency should be 0
}
