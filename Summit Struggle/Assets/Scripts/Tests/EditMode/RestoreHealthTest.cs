using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RestoreHealthTest
{
    [SerializeField] private RestoreHealth rs;
    private Currency currency;
    private PlayerLife playerLife;

   [SetUp]
   public void SetUp(){
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

        // Get the components
        rs = GameObject.FindWithTag("ShopHealth").GetComponent<RestoreHealth>();

        Assert.IsNotNull(rs, "ShopItem component not found on ShopHealth");
   }
    // A Test behaves as an ordinary method
    [Test]
    public void RestoreHealthPass()
    {
        //set up variables
        rs.SetPrice(10);
        rs.SetCurrency(40);
        rs.SetPlayerHealth(40);
        Debug.Log("Healing 40 + 20...");
        rs.Buy();

        Assert.AreEqual(rs.GetHealth(), 60);
    }

   

   
}
