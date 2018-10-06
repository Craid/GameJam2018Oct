using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManagerHandleClick : IHandleClick {

	public GameObject player;
	public GameObject trashItemPlaceHolder;
	public GameObject[] trashItems;

	// Set random trashItem, make player look at item
	public override void HandleClick(){

		foreach (Transform child in trashItemPlaceHolder.transform){
			Destroy(child.gameObject);
		}

		Quaternion q = Quaternion.Euler (new Vector3 (Random.Range(60,360),Random.Range(0,360),Random.Range(60,360)));
		Vector3 pos = Random.insideUnitSphere;
		pos.y = 0;
		pos.Normalize();
		pos *= 2;
		pos = pos + trashItemPlaceHolder.transform.position;

		Instantiate (trashItems [Random.Range (0, trashItems.Length - 1)], pos,q, trashItemPlaceHolder.transform);
		pos.y = player.transform.position.y;
		player.transform.LookAt (pos);
	}
}
