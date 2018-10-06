using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVictoryScript : MonoBehaviour {

	private float time;
	private float animationTime = 0.5f;

	private float victoryTime = 5f;
	private float bossVictoryTime = 10f;

	private bool playedDab;
	private bool startedTrash;

	public Animator playerAnimator;
	public Animator trashAnimator;

	private string victoryTrigger;

	public GameObject levelManager;

	// Use this for initialization
	void Awake () {
		time = 0;
		playedDab = false;
		startedTrash = false;
	}

	void OnEnable(){
		time = 0;
		playedDab = false;
		startedTrash = false;
	}

	void OnDisable(){
		time = 0;
		playedDab = false;
		startedTrash = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > animationTime && !playedDab) {
			playerAnimator.SetTrigger ("PLAYER_DAB");
			trashAnimator.SetTrigger ("Idle");
			playedDab = true;
		}
		if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Player_GetHit") && !startedTrash) {
			trashAnimator.SetTrigger (victoryTrigger);
			startedTrash = true;
		}
		if (startedTrash && victoryTrigger.Equals ("Victory") && time > victoryTime || startedTrash && victoryTrigger.Equals("BossVictory") && time > bossVictoryTime) {
			levelManager.GetComponent<LevelManager>().StopAnimation();
		}
	}

	public void SetVictoryTriggerToVictory(){
		victoryTrigger = "Victory";
	}

	public void SetVictoryTriggerToBossVictory(){
		victoryTrigger = "BossVictory";
	}
}
