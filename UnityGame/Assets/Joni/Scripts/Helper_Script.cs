using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper_Script : MonoBehaviour {

    //Helper attributes
    public string helperName;
    public int count;
    public int price;
    public int trashPerSecond;

    

    //UI-Elements and Scripts
    public Button addOne;
    public Text nameIndicator;
    public Text efficiencyIndicator;
    public Text countIndicator;
    public Text priceIndicator;
    public Clicker clicker;

    // Use this for initialization
    void Start () {
        addOne.onClick.AddListener(ClickAddOne);
        nameIndicator.text = helperName;
        efficiencyIndicator.text = trashPerSecond.ToString();


	}
	
	// Update is called once per frame
	void Update () {
        priceIndicator.text = price.ToString();
        countIndicator.text = count.ToString();
        //efficiencyIndicator.text = trashPerSecond.ToString();
    }

    // multiply the count and the trashperSecond
    public int CalculateTrashPerSecond(){
        return count * trashPerSecond;
    }

    //buy a helper
    void ClickAddOne(){
        if(clicker.GetMoney() - price >= 0){
            clicker.Pay(price);
            price += (int)(price * 0.03);
            count++;
        }
    }

}
