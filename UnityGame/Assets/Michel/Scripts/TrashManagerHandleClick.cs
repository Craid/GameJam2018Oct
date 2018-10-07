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
			DestroyImmediate(child.gameObject);
		}

		Instantiate (trashItems [Random.Range (0, trashItems.Length - 1)], trashItemPlaceHolder.transform);
		player.transform.rotation = Quaternion.Euler(new Vector3 (0, Random.Range(0,360), 0));
	}
}
