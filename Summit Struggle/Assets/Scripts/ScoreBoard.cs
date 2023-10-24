using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    //image
    [SerializeField] private GameObject scoreBoardBackground;
    [SerializeField] private Text Coins;
    [SerializeField] private Text Level;
    [SerializeField] private Text Enemy;

    private PlayerLevel playerLevel;
    private Currency currency;


    // Start is called before the first frame update
    void Start()
    {
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();

        scoreBoardBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            toggleScoreBoard();
        }

        Level.text = "Level: " + playerLevel.level;
        Coins.text = "Coins: " + currency.getnumOfCoins();


    }


    private void toggleScoreBoard ()
    {
        scoreBoardBackground.SetActive(!scoreBoardBackground.activeSelf);
    }
}
