using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseMaxHealth : MonoBehaviour
{
    private Currency currency;

    //get player components
     private PlayerLife playerLife;
     public GameObject messagePrompt;


       //get Shop items
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;

    void Start()
    {
         playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();   
        messagePrompt = GameObject.FindGameObjectWithTag("BuyMessage");
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
            SendConfirmation();

          }
    }

     public void SendConfirmation(){
        messagePrompt.SetActive(true);
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }
}
