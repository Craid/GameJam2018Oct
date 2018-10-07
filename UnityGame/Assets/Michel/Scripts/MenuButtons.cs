using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public GameObject title;
	public GameObject buttons;
	public GameObject credits;

	public void onPlayClick(){
		SceneManager.LoadScene ("MainScene");
	}

	public void onCreditsClick(){
		credits.SetActive (true);
		buttons.SetActive (false);
		title.SetActive (false);
	}

	public void onBackToMenu(){
		credits.SetActive (false);
		buttons.SetActive (true);
		title.SetActive (true);
	}

	public void onExitClick(){
		Application.Quit ();
	}

}
