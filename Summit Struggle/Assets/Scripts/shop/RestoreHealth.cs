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

          public int HealPlayer()
    {
        playerLife.HealPlayer(healing);
        return playerLife.GetHealth();
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }

}
