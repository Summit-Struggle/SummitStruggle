using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class NewTestScript
{

    private SaveLoad saveLoad;

    [UnitySetUp]
    public IEnumerator Setup() 
    { 
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level");
        yield return new WaitForSeconds(0.5f);

        //saveLoad = Object.FindObjectOfType<SaveLoad>();
        saveLoad = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoad>();

        // Set up playerTransform to avoid null reference issues
        //saveLoad.playerTrasform = new GameObject().transform;
    }
    
    [UnityTest]
    public IEnumerator TestSave()
    {
        Debug.Log("has the script: " + saveLoad.getfilePathPrimary());
        
        
        saveLoad.saveGame();



        // Wait for one frame to allow the SaveGame method to complete
        yield return null;
        yield return new WaitForSeconds(0.5f);

        // Get the expected file path
        string expectedFilePath = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");
        Debug.Log(expectedFilePath);

        Debug.Log("File exists ????: " + File.Exists(expectedFilePath));

        //string expected = "C:/Users/zdtuc/Documents/GitHub/SummitStruggle/Summit Struggle/Assets\\Scripts\\Files\\saveFilePrimary.txt";

        // Assert that the saved file exists at the expected path
        Assert.IsTrue(File.Exists(expectedFilePath));
    }
}
