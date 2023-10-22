using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private string filePathPrimary;
    private string filePathSecondary;
    private string testPath;

    private PlayerLife playerLife;
    private PlayerLevel playerLevel;
    [SerializeField] private Transform t;

    // Start is called before the first frame update
    void Awake()
    {
        //gets the other needed scripts to access player data needed for saves
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();


        //file paths to both save files. Dynamic paths, so they will work when parents folders are moved
        //very delicate, don't change if possible.
        filePathPrimary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");
        filePathSecondary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFileSecondary.txt");
        //2 save files so that the user can delete their current save and revert back to the previous.
    }

    // Update is called once per frame
    void Update()
    {
        //when U is pressed load the previous save
        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadSave();
        }

        //when I is pressed down, save the game here.
        if (Input.GetKeyDown(KeyCode.I))
        {
            saveGame();
        }

        //when O is pressed down, the last save is deleted
        if (Input.GetKeyDown(KeyCode.O))
        {
            deleteLastSave();
        }
    }

    public void saveGame()
    {
        //if there is no saves
        if (!File.Exists(filePathPrimary))
        {
            //creates save file
            createSaveFile(filePathPrimary);
            //Debug.Log("Created primary file");
            return;

        } // if there is already a save.


        if (File.Exists(filePathSecondary))
        {
            //deleted old save
            File.Delete(filePathSecondary);
            //Debug.Log("Deleted old file");
        }

        //sets current save to old save
        File.Move(filePathPrimary, filePathSecondary);
        //Debug.Log("Moved old file to old pos");

        //creates a new file at the filepath
        createSaveFile(filePathPrimary);
        //Debug.Log("Created new primary file");

    }

    private void createSaveFile(string filePath)
    {
        //the players position at the time.
        string position = t.position.x + " " + t.position.y + " " + t.position.z;

        //the players health
        string health = playerLife.getHealth() + "";

        //the players xp
        string xp = playerLevel.getXp() + "";

        string saveContents = position + "\n" + health + "\n" + xp;

        //writes the save information onto a txt file.
        try
        {
            File.WriteAllText(filePath, saveContents);
            Debug.Log("Save Successful");
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("Directory not found: " + e);
        }
    }



    public void LoadSave()
    {
        string tempFilePath;

        //sets the file path to the most recent save. Sets it to old save if new save has been deleted. 
        if (File.Exists(filePathPrimary))
        {
            tempFilePath = filePathPrimary;
            Debug.Log("Primary load path found");
        }
        else if (File.Exists(filePathSecondary))
        {
            tempFilePath = filePathSecondary;
            Debug.Log("Secondary load path found");
        }
        else
        {
            //if no saves are avalible, does nothing.
            Debug.Log("No load path found");
            return;
        }

        LoadSave(tempFilePath);
    }

    private void LoadSave(string filePath)
    {
        string[] saveFileLines;

        //gets the lines from the save file
        try
        {
            saveFileLines = File.ReadAllLines(filePath);
        } catch (DirectoryNotFoundException e)
        {
            Debug.Log("Directory not found: " + e);
            return;
        }

        string[] pos = saveFileLines[0].Split(" ");

        
        //sets the players pos to the saved pos
        t.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), t.position.z);

        //sets the players health from saved health
        playerLife.setHealthFromSave(int.Parse(saveFileLines[1]));

        //sets the players xp from saved xp
        playerLevel.SetXP(float.Parse(saveFileLines[2]));
    }

    public void deleteLastSave ()
    {
        //delets first save if it exists
        if(File.Exists(filePathPrimary))
        {
            File.Delete(filePathPrimary);
        } else //otherwise deletes second save.
        {
            File.Delete(filePathSecondary);
        }
    }


}
