using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private PlayerLife playerLife;

    private void Awake()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            int healAmount = (int)((double)playerLife.getMaxHealth() * 0.35);
            playerLife.HealPlayer(healAmount);
            Debug.Log("Hit heart");
        }
    }
}
