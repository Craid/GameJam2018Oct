using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandleClick  : IHandleClick {

	Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}

	//Spawns a new location
	public override void HandleClick(){
		animator.SetTrigger ("PLAYER_PICKUP");
	}

}

