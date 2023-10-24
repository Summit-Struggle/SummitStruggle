using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class NewTestScript
{

    private SaveLoad saveLoad;
    private PlayerLife playerLife;
    private PlayerLevel playerLevel;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");

        saveLoad = Object.FindObjectOfType<SaveLoad>();
        playerLife = Object.FindObjectOfType<PlayerLife>();
        playerLevel = Object.FindObjectOfType<PlayerLevel>();

        Debug.Log(saveLoad == null);

        // Set up playerTransform to avoid null reference issues
        //saveLoad.playerTrasform = new GameObject().transform;
    }

    [UnityTest]
    public IEnumerator TestSaveGame()
    {
        saveLoad.saveGame();
        yield return new WaitForSeconds(0.5f);

        // Get the expected file path
        string expectedFilePath = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");

        Assert.IsTrue(File.Exists(expectedFilePath));
    }

    [UnityTest]
    public IEnumerator save_data_is_correct()
    {
        yield return new WaitForSeconds(0.5f);

        saveLoad.saveGame();
        Transform playerLocation = saveLoad.getPlayerTransform();

        // Get the expected file path
        string filePath = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");
        string[] savedContent = File.ReadAllLines(filePath);

        string expected = playerLocation.position.x + " " + playerLocation.position.y + " " + playerLocation.position.z;

        Assert.AreEqual(expected, savedContent[1]);
    }

    [UnityTest]
    public IEnumerator Load_Save_Test()
    {
        string primarySaveContent = "1\n10 10 0\n100\n0\n10 10 -0.6092805f\n10\n";

        File.WriteAllText(saveLoad.getfilePathPrimary(), primarySaveContent);

        saveLoad.LoadSave();

        Assert.AreEqual(new Vector3(10, 10, 0), saveLoad.getPlayerTransform().position);
        Assert.AreEqual(100, playerLife.getHealth());
        Assert.AreEqual(0, playerLevel.getXp());
        Assert.AreEqual(new Vector3(10, 10, -0.6092805f), saveLoad.getGoblins()[0].transform.position);

        GoblinHealth goblinHealthScript = saveLoad.getGoblins()[0].GetComponent<GoblinHealth>();
        Assert.AreEqual(10, goblinHealthScript.getCurrentHealthForSave());

        yield return null;
    }


}
