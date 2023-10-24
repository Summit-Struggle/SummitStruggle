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
        currency = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        numOfCoins = 0;
        SetCurrency();
        Debug.Log("Starting Currency: " + numOfCoins);
    }

    public int GetCoins() {
        Debug.Log("Retrieving Coins: " + numOfCoins); 
        return numOfCoins;
    }

    public string GetCurrency() {
        return currency.ToString();
    }

    //update UI
    private void SetCurrency() { 
        string currencyText = numOfCoins.ToString();
        currency.text = currencyText;
    }

    //SetCoins for testing
    public void SetCoins(int amount){
         if(currency != null){
            numOfCoins = amount;

            Debug.Log("Coins != null, New currency: " + amount);
        }
        else{
            //get currency then apply
            currency = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();

            numOfCoins = amount;

            Debug.Log("currency test = null, New currency: " + amount);
        }
      
        SetCurrency();
        Debug.Log("SetTestCoins: " + numOfCoins);
    }

   public int GainCoins(int amount) {
        numOfCoins += amount;
        SetCurrency();
        Debug.Log("Adding coins: " + amount);
        return numOfCoins;
    }

      public void LoseCoins(int amount) {
        numOfCoins -= amount;
        Debug.Log("Removing coins: " + amount);
        SetCurrency();
    }


    public int getnumOfCoins ()
    {
        return numOfCoins;
    }

    //can set tests for currency increasing when enemy dies

    //test - when player buys something currency decreases.

    //when level loads the currency should be 0
}
