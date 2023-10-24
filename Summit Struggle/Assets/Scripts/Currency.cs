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
        numOfCoins = amount;
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
}
