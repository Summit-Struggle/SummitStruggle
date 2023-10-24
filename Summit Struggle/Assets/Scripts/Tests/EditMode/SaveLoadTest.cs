using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class SaveLoadTest
{
    private SaveLoad saveLoad;
    private PlayerLife playerLife;
    private PlayerLevel playerLevel;

    [SetUp]
    public void setUp ()
    {
        //saveLoad = Object.FindObjectOfType<SaveLoad>();
        //playerLife = Object.FindObjectOfType<PlayerLife>();
        //playerLevel = Object.FindObjectOfType<PlayerLevel>();

        saveLoad = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoad>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();

    }

    // A Test behaves as an ordinary method
    [Test]
    public void Test_Load()
    {
        string primarySaveContent = "1\n10 10 0\n100\n0\n10 10 0\n10\n";

        File.WriteAllText(saveLoad.getfilePathPrimary(), primarySaveContent);

        saveLoad.LoadSave();

        Assert.AreEqual(new Vector3(0, 0, 0), saveLoad.getPlayerTransform().position);
        Assert.AreEqual(100, playerLife.getHealth());
        Assert.AreEqual(0, playerLevel.getXp());
    }
}
