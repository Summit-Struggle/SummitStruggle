using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealth : MonoBehaviour
{
    private Currency currency;

     private PlayerLife playerLife;


    //get Shop items
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;
   //amount set for healing
     [SerializeField] private int healing = 20;


    // Start is called before the first frame update
    void Start()
    {
       currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
       playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();   
    }

    // Update is called once per frame
      public void Buy(){
      
        
        int price = int.Parse(itemPrice.text);
        string item = itemName.text.ToString();
        Debug.Log("buying " + item + "...");

          if(CheckPrice(price))
          {
            currency.LoseCoins(price);
             HealPlayer();
          }


      }

    public void HealPlayer()
    {
        playerLife.HealPlayer(healing);
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }

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

    public int GetHealth()
    {
        return playerLife.GetHealth();
    }

     public void SetPlayerHealth(int amount)
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLife.SetCurrentHealth(amount);
        Debug.Log("New player health: " + amount);
    }

}
