using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField]public float XP;
    public float level;
    [SerializeField] private Text text;

    public PlayerLevel() //constructor
    {
        XP = 0;
        level = 1;
    }
    public void CalculateLevel()
    {
        float calculatedLevel = XP / 100;
        level = calculatedLevel;

        text.text = "Level: " + level;

    }


    public void Update()
    {
        CalculateLevel();
        Debug.Log("Level: " + level + " XP: " + XP);
    }

    public int getXp ()
    {
        return (int)XP;
    }

    public void SetXP (float xp)
    {
        XP = xp;
    }

}