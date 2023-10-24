using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    //image
    [SerializeField] public GameObject scoreBoardBackground;
    [SerializeField] public Text Coins;
    [SerializeField] public Text Level;
    [SerializeField] public Text Kills;

    private PlayerLevel playerLevel;
    private Currency currency;
    private PlayerAttack playerAttack;


    // Start is called before the first frame update
    void Start()
    {
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

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
        Kills.text = "Kills: " + playerAttack.numOfKills;
    }


    public void toggleScoreBoard ()
    {
        scoreBoardBackground.SetActive(!scoreBoardBackground.activeSelf);
    }
}
