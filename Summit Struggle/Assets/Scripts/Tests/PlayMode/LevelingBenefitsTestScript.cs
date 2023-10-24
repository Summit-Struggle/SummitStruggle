using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LevelingBenefitsTestScript
{
    private LevelingBenefits levelingBenefits;
    private PlayerLevel playerLevel;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");
        
        levelingBenefits = Object.FindObjectOfType<LevelingBenefits>();
        playerLevel = Object.FindObjectOfType<PlayerLevel>();
    }

    [UnityTest]
    public IEnumerator TestBenefitCalculation()
    {
        
        playerLevel.level = 3; //sets the level so we can do the calculation below to check if they match and pass the unit test

        float coins = levelingBenefits.BenefitCalculation(); //calculates the coin using the benefit calculation method
        float expectedCoins = 5 * Mathf.Ceil(playerLevel.level); //calcukates the expected coins using the math for it and player level.
        Assert.AreEqual(expectedCoins , coins, 0.001f); //checks if the values match

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLevelText()
    {
        playerLevel.level = 3; //sets the player level so we can calculate the expected result
        levelingBenefits.Update(); //calls update which sets the text
        Text levelText = levelingBenefits.level; //gets the text
        string expectedLevelText = "Level: " + playerLevel.level; //calculates the expected level

        Assert.AreEqual(expectedLevelText, levelText.text); //checks if the texts match to determine if the unit test passes or not

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestRewardsText()
    {
        playerLevel.level = 3;  //sets the player level that is used to determine the expected result
        levelingBenefits.BenefitCalculation(); //calls the method which calculate the benefits, but al;s

        Text rewardsText = levelingBenefits.rewards; //gets the rewards text from LevelingBenefits and saves it into this text variable

        int roundedLevel = Mathf.CeilToInt(playerLevel.level); //calculates the rounded level which is used to calculate the coins below
        float coins = 5 * roundedLevel; //uses the math formula found in BenefitCalculation and the rounded level to determine the expected result
        string expectedRewardsText = "Rewards for next level are: " + coins + " coins"; //determines the expected result for the test

        Assert.AreEqual(expectedRewardsText, rewardsText.text); //checks if the texts match each other and based on the results determines whether or not the unit test passes or fails

        yield return null;
    }
}
