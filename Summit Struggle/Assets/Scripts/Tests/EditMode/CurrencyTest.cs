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
        //start clean
        int check = 0;
        currency.SetCoins(0);

        Debug.Log("Currency: " + currency.GetCoins());
        Assert.AreEqual(currency.GetCoins(), check);
    }

     [Test]
    public void AddCurrency()
    {
        //reset  values
        currency.SetCoins(0);
        //call addCurrency

        //check in currency = expected value
        Assert.AreEqual(currency.GainCoins(30), 30);
    }

   
}
