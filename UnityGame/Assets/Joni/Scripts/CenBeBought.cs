using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenBeBought : MonoBehaviour {

    public Clicker clicker;
    public Button addButton;

    int price;
    int money;


	
	// Update is called once per frame
	void Update () {
        price = GetComponent<Helper_Script>().price;
        money = clicker.GetMoney();

        if(price < money){
            addButton.interactable = true;
        }
        if(price > money){
            addButton.interactable = false;
        }


	}
}
