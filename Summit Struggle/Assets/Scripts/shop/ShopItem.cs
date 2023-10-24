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
    

    public void Buy(){
      
        
        int price = int.Parse(itemPrice.text);
        string item = itemName.text.ToString();
        Debug.Log("buying " + item + "...");


       if(CheckPrice(price)){
           switch(item)
           {
            case "Restore Health":
                currency.LoseCoins(price);
                RestoreHealth();
                break;
            case "Increase Attack":
                currency.LoseCoins(price);
                IncreaseAttack();
                break;
            case "Increase Max Health":
                currency.LoseCoins(price);
                IncreaseMaxHealth();
                break;
            default: 
            Debug.Log("Invalid item");
            break;

           }
       }


    }

    public void IncreaseMaxHealth(){
        //defaullt amount increase each time
        int amount = 10;
        playerLife.UpdateMaxHealth(amount);
    }

    public void IncreaseAttack(){
        Debug.Log(playerAttack.IncreaseAttack(5));
    }
    public int RestoreHealth()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLife.HealPlayer(healing);
        return playerLife.GetHealth();
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


     public void SetPlayerHealth(int amount)
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLife.SetCurrentHealth(amount);
        Debug.Log("New player health: " + amount);
    }
}
