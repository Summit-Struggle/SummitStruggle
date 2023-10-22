using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CurrencyTest
{

    //get currency 
    private Currency currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();

    // A Test behaves as an ordinary method
    [Test]
    public void startingCurrency()
    {
        Currency start = new Currency();
        int check = 0;

        Debug.Log("Currency: " + start.getCoins());
        Assert.AreEqual(start.getCoins(), check);
    }

     [Test]
    public void AddCurrency()
    {
        Currency currencyInstance = new Currency();

        //call addCurrency
        currencyInstance.gainCoins(30);

        //check in currency = expected value
        // Use the Assert class to test conditions
        Assert.AreEqual(currencyInstance.gainCoins(30), 30);
    }

    // public void AddCurrencyText()
    // {
    //     Currency nextCurrency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
    //     //get text UI
        
    //     //call addCurrency
    //     nextCurrency.gainCoins(30);

    //     //check UI text = expected value after adding currency
    //     Assert.AreEqual(nextCurrency.getCurrency(), "30");
    // }

   
}
