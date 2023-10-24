using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseAttack : MonoBehaviour
{
    private Currency currency;

    //get player components
     private PlayerAttack playerAttack;

       //get Shop items
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;

    void Start()
    {
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }
    public void Buy()
    {
        
        int price = int.Parse(itemPrice.text);
        string item = itemName.text.ToString();
        Debug.Log("buying " + item + "...");

          if(CheckPrice(price))
          {
            currency.LoseCoins(price);
            Debug.Log(playerAttack.IncreaseAttack(5));


          }
    }

    public bool CheckPrice(int price)
    {
        return  price <= currency.GetCoins();
    }
}
