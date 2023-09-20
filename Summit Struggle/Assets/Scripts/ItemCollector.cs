using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private PlayerLife playerLife;

    private void Awake()
    {
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicStuff>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("Cherries: " + cherries);
            cherriesText.text = "Cherries: " + cherries;
            collectionSoundEffect.Play();
        }

        if(collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            int healAmount = (int)((double)playerLife.getMaxHealth() * 0.35);
            playerLife.HealPlayer(healAmount);
        }



    }



}
