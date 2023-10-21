using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    //set initial currency
    private int currency = 0;
    [SerializeField] private TextMeshPro coins;

    // Start is called before the first frame update
    void Start()
    {
        currency = 20;
    }


    //update UI
    private void SetCurrency(int currency) { 
        coins.text = currency;
    }

    //Buy




    //can set tests for currency increasing when enemy dies

    //test - when player buys something currency decreases.

    //when level loads the currency should be 0
}
