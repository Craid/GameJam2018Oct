using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : IHandleClick {

	IHandleClick[] handleClickList;

	public GameObject currentLevel;
	public GameObject level;

	public GameObject trashManager;
	public GameObject showVictory;


	void Start(){
		Instantiate (level, currentLevel.transform);
		handleClickList = GetComponentsInChildren<IHandleClick>();

		trashManager.SetActive (true);
		showVictory.SetActive (false);

	}

	//Triggers all registeres handleClick Interfaces
	public override void HandleClick(){
		foreach (IHandleClick handleClickItem in handleClickList) {
			if ( handleClickItem.GetInstanceID() != GetInstanceID() )
			{
				handleClickItem.HandleClick ();
			}
		}
	}

	public void setLevel(int levelNumber){
		updateLevel (levelNumber);

		trashManager.SetActive (false);
		showVictory.SetActive (true);

		if (levelNumber % 5 == 0)
			StartBossVictoryAnimation ();
		else
			StartVictoryAnimation ();
	}

	private void updateLevel(int levelNumber){
		currentLevel.GetComponentInChildren<VegetationSpawner> ().SetLevel (levelNumber);
	}

	private void StartVictoryAnimation(){
		Debug.Log ("Play Victory");
		showVictory.GetComponent<ShowVictoryScript>().SetVictoryTriggerToVictory();
	}

	private void StartBossVictoryAnimation(){
		Debug.Log ("Play BossVictory");
		showVictory.GetComponent<ShowVictoryScript>().SetVictoryTriggerToBossVictory();
	}

	public void StopAnimation(){
		trashManager.SetActive (true);
		showVictory.SetActive (false);
	}
}
