using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{

    //number of enemys
    int numOfEnemys = 1;

    private string filePathPrimary;
    private string filePathSecondary;
    private string testPath;

    private PlayerLife playerLife;
    private PlayerLevel playerLevel;
    [SerializeField] private Transform playerTrasform;

    [SerializeField] private Transform goblicTrasform;
    private GoblinHealth goblinHealthScript;

    [SerializeField] private Text popUpText;
    private float popupTimer;
    private bool textVisibility;

    // Start is called before the first frame update
    void Awake()
    {
        //gets the other needed scripts to access player data needed for saves
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        goblinHealthScript = GameObject.FindGameObjectWithTag("goblin").GetComponent<GoblinHealth>();

        //file paths to both save files. Dynamic paths, so they will work when parents folders are moved
        //very delicate, don't change if possible.
        filePathPrimary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");
        filePathSecondary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFileSecondary.txt");
        //2 save files so that the user can delete their current save and revert back to the previous.
    }

    private void Start()
    {
        popUpText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        //when U is pressed load the previous save
        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadSave();
            ShowPopupText("Previous Save Loaded", 2);
        }

        //when I is pressed down, save the game here.
        if (Input.GetKeyDown(KeyCode.I))
        {
            saveGame();
            ShowPopupText("Saved", 2);
        }

        //when O is pressed down, the last save is deleted
        if (Input.GetKeyDown(KeyCode.O))
        {
            deleteLastSave();
            ShowPopupText("Deleted Last Save", 2);
        }

        if (textVisibility)
        {
            // Decrease the timer
            popupTimer -= Time.deltaTime;

            // Check if the timer has reached 0
            if (popupTimer <= 0f)
            {
                // Hide the text
                HidePopupText();
            }
        }

    }

    void ShowPopupText(string message, float duration)
    {
        // Set the text message
        popUpText.text = message;

        // Enable the text element
        popUpText.enabled = true;

        // Set the timer
        popupTimer = duration;

        // Set popup visibility flag
        textVisibility = true;
    }

    void HidePopupText()
    {
        // Disable the text element
        popUpText.enabled = false;

        // Reset popup visibility flag
        textVisibility = false;
    }

    public void saveGame()
    {
        //if there is no saves
        if (!File.Exists(filePathPrimary))
        {
            //creates save file
            createSaveFile(filePathPrimary);
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

        //creates a new file at the filepath
        createSaveFile(filePathPrimary);

    }

    private void createSaveFile(string filePath)
    {
        //the players position at the time.
        string position = playerTrasform.position.x + " " + playerTrasform.position.y + " " + playerTrasform.position.z;

        //the players health
        string health = playerLife.getHealth() + "";

        //the players xp
        string xp = playerLevel.getXp() + "";

        //goblic location
        string goblinLocation = goblicTrasform.position.x + " " + goblicTrasform.position.y + " " + goblicTrasform.position.z;

        //goblics health
        string goblinHealth = goblinHealthScript.getCurrentHealthForSave() + "";

        //all save contents
        string saveContents = position + "\n" + health + "\n" + xp + "\n" + goblinLocation + "\n" + goblinHealth;

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
        }
        else if (File.Exists(filePathSecondary))
        {
            tempFilePath = filePathSecondary;
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

        string[] playerPos = saveFileLines[0].Split(" ");
        string[] goblicPos = saveFileLines[3].Split(" ");


        //sets the players pos to the saved pos
        playerTrasform.position = new Vector3(float.Parse(playerPos[0]), float.Parse(playerPos[1]), playerTrasform.position.z);

        //sets the players health from saved health
        playerLife.setHealthFromSave(int.Parse(saveFileLines[1]));

        //sets the players xp from saved xp
        playerLevel.SetXP(float.Parse(saveFileLines[2]));

        //sets the goblin's location from save file
        goblicTrasform.position = new Vector3(float.Parse(goblicPos[0]), float.Parse(goblicPos[1]), goblicTrasform.position.z);

        goblinHealthScript.setCurrentHealthForSave(float.Parse(saveFileLines[4]));
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
