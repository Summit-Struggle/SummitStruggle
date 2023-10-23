using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTest
{
    private ShopItem Item = GameObject.FindGameObjectWithTag("ShopHealth").GetComponent<ShopItem>();
    private PlayerLife Life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();



    // A Test behaves as an ordinary method
    [Test]
    //test if buy function works when currency > price
    public void PriceCheckPassTest()
    {
        //set testing values
        Item.SetCurrency(40);

        //after bought, check num of coins
        Assert.IsTrue(Item.CheckPrice(20));
    }


    [Test]
     //test if buy function fails when currency > price
    public void PriceCheckFailTest()
    {
        //set testing values
        Item.SetCurrency(10);

        //after bought, check num of coins
        Assert.IsFalse(Item.CheckPrice(20));
    }

    // check restore health working
    [Test]
    public void RestoreHealthCheck()
    {
        Item.SetPlayerHealth(60);
        Item.RestoreHealth();

        Assert.AreEqual(Item.GetPlayerHealth(), 80);
    }

    //test coins are lost when item bought
    [Test]
    public void buyItemBought(){
        Item.SetCurrency(50);
        Item.SetName("Restore Health");
        Item.SetPrice(10);

        Item.buy();

        Assert.AreEqual(Item.GetCurrency(), 40);
    }

}
