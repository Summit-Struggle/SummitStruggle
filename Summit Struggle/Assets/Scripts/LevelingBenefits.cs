using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingBenefits : MonoBehaviour
{
    
    public GameObject Header;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //checks for the users input of L key and opens/closes the menu based on whether its open or closed.
        {
            ToggleHeaderVisibility();
        }
    }

    private void ToggleHeaderVisibility()
    {
        // Toggle the active state of the header
        Header.SetActive(!Header.activeSelf);
    }
}

