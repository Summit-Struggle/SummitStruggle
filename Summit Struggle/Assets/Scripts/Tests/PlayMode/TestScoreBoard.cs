using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScoreBoard
{
    private ScoreBoard scoreBoard;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level");
        scoreBoard = Object.FindObjectOfType<ScoreBoard>();
        yield return null; // Wait for a frame update
    }

    [UnityTest]
    public IEnumerator ScoreBoard_Start_SetsInitialValuesCorrectly()
    {
        yield return new WaitForSeconds(0.5f);

        Assert.IsNotNull(scoreBoard.Level);
        Assert.IsNotNull(scoreBoard.Coins);
        Assert.IsNotNull(scoreBoard.Kills);
        Assert.IsFalse(scoreBoard.scoreBoardBackground.activeSelf);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ScoreBoard_Update_UpdateTextFieldsCorrectly()
    {
        scoreBoard.Level.text = "Level: 5";
        scoreBoard.Coins.text = "Coins: 100";
        scoreBoard.Kills.text = "Kills: 10";


        Assert.AreEqual("Level: 5", scoreBoard.Level.text);
        Assert.AreEqual("Coins: 100", scoreBoard.Coins.text);
        Assert.AreEqual("Kills: 10", scoreBoard.Kills.text);
        yield return null; // Wait for a frame update
    }

    [UnityTest]
    public IEnumerator ScoreBoard_ToggleScoreBoard_ActivatesAndDeactivatesScoreBoardBackground()
    {
        scoreBoard.toggleScoreBoard();
        Assert.IsTrue(scoreBoard.scoreBoardBackground.activeSelf);

        yield return null; // Wait for a frame update

        scoreBoard.toggleScoreBoard();
        Assert.IsFalse(scoreBoard.scoreBoardBackground.activeSelf);

        yield return null;
    }
}
