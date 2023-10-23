using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public PlayerLife playerLife;

    void Start()
    { 
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>(); //initializes the PlayerLife so the ResetGame method can be called to rest the level
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //checks for the users input of R key and resets the game if it is pressed
        {
            playerLife.ResetGame(); // line to reset the game
        }
    }
}
