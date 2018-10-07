using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutSceneScript : MonoBehaviour {

	void OnEnable(){
		LoadStartScene ();
	}

	void StopMusic(){
		GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioPlayerScript> ().StopMusic ();
	}

	void LoadStartScene(){
		SceneManager.LoadScene ("StartScene");
	}
}
