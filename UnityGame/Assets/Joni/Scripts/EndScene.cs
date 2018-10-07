using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {


    public Text trashSelfIndicator;
    public Text trashHelperIndicator;
    Clicker clicker;
    // Use this for initialization
    void Start () {
        clicker = GetComponent<Clicker>();
        trashSelfIndicator.text = clicker.trashCollected.ToString();
        trashHelperIndicator.text = clicker.GetHelperTrash().ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
