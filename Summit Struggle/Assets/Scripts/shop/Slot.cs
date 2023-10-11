using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{

    [SerializeField] public Image itemImage;
    [SerializeField] public TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI itemPrice;
    [SerializeField] public TextMeshProUGUI itemAmount;

    [SerializeField] public GameObject itemToBuy;
    [SerializeField] public int _ItemAmount;
    [SerializeField] public TextMeshProUGUI buyPriceText;


    // Start is called before the first frame update
    void Start()
    {
        // itemName.text = itemToBuy.GetComponent<>().itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
