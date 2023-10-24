using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseMaxHealth : MonoBehaviour
{
    private Currency currency;

    //get player components
     private PlayerLife playerLife;

       //get Shop items
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;

    void Start()
    {
       playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();   

        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
    }
    public void Buy()
    {
        
        int price = int.Parse(itemPrice.text);
        string item = itemName.text.ToString();
        Debug.Log("buying " + item + "...");

          if(CheckPrice(price))
          {
            currency.LoseCoins(price);
            playerLife.UpdateMaxHealth(10);
            Debug.Log("Current Max Health: " + playerLife.getMaxHealth());

          }
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }
}
