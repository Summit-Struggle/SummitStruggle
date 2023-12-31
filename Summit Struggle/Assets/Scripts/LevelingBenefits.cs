using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelingBenefits : MonoBehaviour
{
    public PlayerLevel playerLevel;
    public Text level;
    public Text rewards;
    public GameObject Header;

    public void Awake()
    {
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>(); //initializes the PlayerLevel to make sure its correct
 
        Header.SetActive(false); // Makes the benefits level UI not showing when the game starts 
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //checks for the users input of L key and opens/closes the menu based on whether its open or closed.
        {
            ToggleHeaderVisibility();
        }

        level.text = "Level: " + playerLevel.level;

        BenefitCalculation();
    }

    private void ToggleHeaderVisibility()
    {
        // Toggle the active state of the header
        Header.SetActive(!Header.activeSelf);
    }

    public float BenefitCalculation()
    {
        int roundedLevel = Mathf.CeilToInt(playerLevel.level); // Rounds up the level so its calculating the rewards for the next level
        float coins = 5 * roundedLevel;
        rewards.text = "Rewards for next level are: " + coins + " coins";
        return coins;
    }

    public void SetPlayerLevel(PlayerLevel newPlayerLevel)
    {
        playerLevel = newPlayerLevel;
    }
}

