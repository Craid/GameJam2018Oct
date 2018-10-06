using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : IHandleClick {

	IHandleClick[] handleClickList;

	public GameObject currentLevel;
	public GameObject level;


	public GameObject trashManager;
	public GameObject showVictory;

	int levelASD = 1;

	void Start(){
		Instantiate (level, currentLevel.transform);
		handleClickList = GetComponentsInChildren<IHandleClick>();

		updateLevel (1);

		InvokeRepeating ("UpLevel", 0, 3f);
		InvokeRepeating ("HandleClick", 0, 1f);
	}

	private void UpLevel(){
		levelASD++;
		updateLevel (levelASD);
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

		if (levelNumber % 5 == 0)
			StartBossVictoryAnimation ();
		else
			StartVictoryAnimation ();
	}

	private void updateLevel(int levelNumber){

		level.GetComponentsInChildren<VegetationSpawner> ()[0].SetLevel (levelNumber);
	}

	private void StartVictoryAnimation(){
		trashManager.SetActive (false);
		showVictory.SetActive (true);
		showVictory.GetComponent<ShowVictoryScript>().SetVictoryTriggerToVictory();
	}

	private void StartBossVictoryAnimation(){
		trashManager.SetActive (false);
		showVictory.SetActive (true);
		showVictory.GetComponent<ShowVictoryScript>().SetVictoryTriggerToBossVictory();
	}

	public void StopAnimation(){
		trashManager.SetActive (true);
		showVictory.SetActive (false);
	}
}
