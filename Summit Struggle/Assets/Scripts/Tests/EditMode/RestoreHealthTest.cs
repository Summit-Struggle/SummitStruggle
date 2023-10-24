using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthTests
{
    private RestoreHealth restoreHealth;

    [SetUp]
    public void Setup()
    {
        //set up gameobject for testing
        GameObject gameObject = new GameObject();
        restoreHealth = gameObject.AddComponent<RestoreHealth>();
        restoreHealth.currency = gameObject.AddComponent<Currency>();
        restoreHealth.playerLife = gameObject.AddComponent<PlayerLife>();
        restoreHealth.itemPrice = gameObject.AddComponent<Text>();
    }

    [Test]
    public void BuyWithEnoughCoins()
    {
        restoreHealth.SetCurrency(100); // Set initial currency
        restoreHealth.SetPrice(20); // Set item price
        restoreHealth.SetPlayerHealth(80); // Set player health

        Debug.Log("Buying potion...");
        restoreHealth.Buy();

        Assert.AreEqual(restoreHealth.GetCurrency(), 80, "Currency should be deducted");
        Assert.AreEqual(restoreHealth.GetHealth(), 100, "Player should be healed");
    }

    [Test]
    public void BuyWihoutEnoughCoins()
    {
        restoreHealth.SetCurrency(10); // Set initial currency
        restoreHealth.SetPrice(20); // Set item price
        restoreHealth.SetPlayerHealth(80); // Set player health

        restoreHealth.Buy();

        Assert.AreEqual(restoreHealth.GetCurrency(), 10, "Currency should not be deducted");
        Assert.AreEqual(restoreHealth.GetHealth(), 80, "Player should not be healed");
    }

    [Test]
    public void CheckPriceWithEnoughCoins()
    {
        restoreHealth.SetCurrency(30); // Set initial currency
        restoreHealth.SetPrice(20); // Set item price

        bool canBuy = restoreHealth.CheckPrice(20);

        Assert.IsTrue(canBuy, "CheckPrice should return true");
    }

    [Test]
    public void CheckPriceWithoutEnoughCoins()
    {
        restoreHealth.SetCurrency(10); // Set initial currency
        restoreHealth.SetPrice(20); // Set item price

        bool canBuy = restoreHealth.CheckPrice(20);

        Assert.IsFalse(canBuy, "CheckPrice should return false");
    }
}
