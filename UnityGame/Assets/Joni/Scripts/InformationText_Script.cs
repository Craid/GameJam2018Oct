using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationText_Script : MonoBehaviour {

    Color color;

	// Use this for initialization
	void Start () {
        color = Color.red;
        GetComponent<Text>().color = this.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
