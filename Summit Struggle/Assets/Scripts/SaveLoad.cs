using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SaveLoad : MonoBehaviour
{

    //holds a array of the enemys
    [SerializeField] private GameObject[] goblins;
    private int numberOfGoblins;

    private string filePathPrimary;
    private string filePathSecondary;

    private PlayerLife playerLife;
    private PlayerLevel playerLevel;
    [SerializeField] public Transform playerTrasform;

    [SerializeField] private Text popUpText;
    private float popupTimer;
    private bool textVisibility;

    // Start is called before the first frame update
    void Awake()
    {
        //gets the other needed scripts to access player data needed for saves
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();

        //file paths to both save files. Dynamic paths, so they will work when parents folders are moved
        //very delicate, don't change if possible.
        filePathPrimary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFilePrimary.txt");
        Debug.Log(filePathPrimary);
        filePathSecondary = Path.Combine(Application.dataPath, "Scripts\\Files", "saveFileSecondary.txt");
        //2 save files so that the user can delete their current save and revert back to the previous.

        numberOfGoblins = goblins.Length;
    }

    private void Start()
    {
        popUpText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        numberOfGoblins = goblins.Count(item => item != null);

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


        //all save contents
        string saveContents = numberOfGoblins + "\n" + position + "\n" + health + "\n" + xp;


        for (int i = 0; i < goblins.Length; i++)
        {
            //saves location
            Transform goblicLocation = goblins[i].transform;
            string location = goblicLocation.position.x + " " + goblicLocation.position.y + " " + goblicLocation.position.z;

            //saves health
            GoblinHealth goblinHealthScript = goblins[i].GetComponent<GoblinHealth>();
            string goblinHealth = goblinHealthScript.getCurrentHealthForSave() + "";

            saveContents += "\n" + location + "\n" + goblinHealth;
        }

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
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("Directory not found: " + e);
            return;
        }


        //stores the information of from the save file into a readable format
        string[] playerPos = saveFileLines[1].Split(" ");

        List<string[]> goblinPositions = new List<string[]>();
        string[] goblicHealths = new string[numberOfGoblins];

        int counterPos = 4;
        int counterHeal = 0;

        //starts at 4 as thats the line that its on
        for (int i = 0; i < numberOfGoblins; i++)
        {
            //takes the goblin's position in a string array
            goblinPositions.Add(saveFileLines[counterPos].Split(" "));
            //sets the goblins health at the index after the pos
            goblicHealths[counterHeal++] = saveFileLines[++counterPos];
            counterPos++;
        }

        //sets the players pos to the saved pos
        playerTrasform.position = new Vector3(float.Parse(playerPos[0]), float.Parse(playerPos[1]), playerTrasform.position.z);

        //sets the players health from saved health
        playerLife.setHealthFromSave(int.Parse(saveFileLines[2]));

        //sets the players xp from saved xp
        playerLevel.SetXP(float.Parse(saveFileLines[3]));

        for (int i = 0; i < numberOfGoblins; i++)
        {
            //gets the goblins transform
            Transform goblinTransform = goblins[i].transform;
            //sets the transform x and y to the i'th position of the goblin positions at the x and y index's (goblinPositions[0][0] = first element of first string array)
            goblinTransform.position = new Vector3(float.Parse(goblinPositions[i][0]), float.Parse(goblinPositions[i][1]), goblinTransform.position.z);

            GoblinHealth goblinHealthScript = goblins[i].GetComponent<GoblinHealth>();
            goblinHealthScript.setCurrentHealthForSave(float.Parse(goblicHealths[i]));

            if (goblinHealthScript.getCurrentHealthForSave() > 0)
            {
                goblinHealthScript.setActive(true);
            } else
            {
                goblinHealthScript.setActive(false);
            }

        }
    }

    public void deleteLastSave()
    {
        //delets first save if it exists
        if (File.Exists(filePathPrimary))
        {
            File.Delete(filePathPrimary);
        }
        else //otherwise deletes second save.
        {
            File.Delete(filePathSecondary);
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

    public string getfilePathPrimary()
    {
        return filePathPrimary;
    }


}
