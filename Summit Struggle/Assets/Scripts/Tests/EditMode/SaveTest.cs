using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;

public class SaveTest
{
    private SaveLoad saveLoad;


    [SetUp]
    public void SetUp ()
    {
        saveLoad = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoad>();
        saveLoad.playerTrasform = new GameObject().transform;
    }



    [Test]
    public void SaveGame_WhenCalled_FileExists()
    {
        saveLoad.saveGame();

        Assert.Equals(saveLoad.getfilePathPrimary(), "C:/Users/zdtuc/Documents/GitHub/SummitStruggle/Summit Struggle/Assets\\Scripts\\Files\\saveFilePrimary.txt");
    }
}
