using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardListener : MonoBehaviour {

    public Button grandma;
    public Button hippie;
    public Button garbage;
    public Button garbageTruck;
    public Button garbageSuctionMaschine;
    public Button clicker;

    public Clicker clickerScript;

	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.F9)){
            Debug.Log("CHeat");
            clickerScript.Cheat();
        }

        if(Input.anyKeyDown){
            clicker.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            grandma.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            hippie.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            garbage.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            garbageTruck.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            garbageSuctionMaschine.onClick.Invoke();
        }
	}
}
