using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeybindUI : MonoBehaviour
{
 //public GameObject keyBindingMenu; // Reference to the key binding change menu UI panel

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    // Start is called before the first frame update
    public Text right, left, jump, attack;

    private GameObject currentKey;
    public Canvas settingsCanvas;
   // private PauseMenuUI pauseMenuUI;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

    public KeyCode GetKeyBinding(string action)
    {
        if (keys.ContainsKey(action))
        {
            return keys[action];
        }
        else
        {
            Debug.LogError("Key binding for action " + action + " not found.");
            return KeyCode.None; // Return a default value in case of an error
        }
    }


    void Start()
    {
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        //keys.Add("Attack", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "Left-click")));



        right.text = keys["Right"].ToString();
        left.text = keys["Left"].ToString();
        jump.text = keys["Jump"].ToString();
        //attack.text = keys["Attack"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Right"]))
        {
            // Do a move action
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            // Do a move action
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Jump"]))
        {
            // Do a move action
            Debug.Log("Jump");
        }
        //if (Input.GetKeyDown(keys["Attack"]))
        //{
         //   // Do a move action
         //   Debug.Log("Attack");
       // }
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }

    /*public void OpenKeyBindingMenu()
    {
        keyBindingMenu.SetActive(false); // Activate the menu to make it visible to the player

    }*/

    public void SaveKey()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
            Debug.Log("Saved key: " + key.Key + " with value: " + key.Value.ToString());
        }

        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs saved.");
    }

    public void ToggleSettingsMenu()
    {
        Debug.Log("ToggleSettingsMenu called");
        settingsCanvas.enabled = true;
        Debug.Log("settingsCanvas.enabled: " + settingsCanvas.enabled);
    }

}
