using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider; // slider from the unity engine for health bar

    public void SetHealth(int health) //function that sets the health of the bar/slider
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(int health) // function to call that sets the max health of the healthbar
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
