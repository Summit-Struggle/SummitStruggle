using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTest
{
     private ShopItem Item;
    private PlayerLife Life;

    [SetUp]
    public void SetUp()
    {
        // Find game objects with tags
        GameObject shopHealthObject = GameObject.FindWithTag("ShopHealth");

        // Check if the objects were found
        Assert.IsNotNull(shopHealthObject, "ShopHealth game object not found");

        // Get the components
        Item = shopHealthObject.GetComponent<ShopItem>();

        Assert.IsNotNull(Item, "ShopItem component not found on ShopHealth");
    }

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
        int expected = 80;
        Debug.Log("Restoring health: + 20 ");

        Assert.AreEqual(Item.RestoreHealth(), expected);
    }

    //test coins are lost when item bought
    [Test]
    public void buyItemBought(){
        Item.SetCurrency(50);
        Item.SetName("Restore Health");
        Item.SetPrice(10);

        Item.Buy();

        Assert.AreEqual(Item.GetCurrency(), 40);
    }

}
