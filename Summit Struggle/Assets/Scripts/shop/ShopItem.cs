using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour
{
    //get currency
    [SerializeField] private Currency currency;

    //get player components
     private PlayerAttack playerAttack;
     private PlayerLife playerLife;


    //get Shop items
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;
   //amount set for healing
     [SerializeField] private int healing = 20;
    public void start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

    }
    

    public bool buy(){
        int price = int.Parse(itemPrice.text);
        Debug.Log("buying " + itemName.text + "...");

       if(CheckPrice(price)){
            if(itemName.text.Equals("Restore Health"))
            {
                currency.LoseCoins(price);
                RestoreHealth();
            }

            else{
                Debug.Log("No item in shop!");
            }
       }

       return false;

    }
    public void RestoreHealth()
    {
        playerLife.HealPlayer(healing);
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }

    //Testing methods-----------------------------
    public void SetName(string name){
        itemName.text = name;
        Debug.Log("New name: " + name);
    }

    public void SetPrice(int price){
        itemPrice.text = price.ToString();
        Debug.Log("New price: " + price);
    }

//set coins for testing
    public void SetCurrency(int amount){
        currency.SetCoins(amount);
        Debug.Log("New currency: " + amount);
    }

    public int GetCurrency()
    {
        return currency.GetCoins();
    }

    public int GetPlayerHealth()
    {
        return playerLife.GetHealth();
    }

     public int SetPlayerHealth(int amount)
    {
        playerLife.SetCurrentHealth(amount);
        return playerLife.GetHealth();
    }
}
