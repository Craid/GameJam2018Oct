﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationSpawner : IHandleClick {


	public List<GameObject> bigSpawns = new List<GameObject>();
	public List<GameObject> smallSpawns = new List<GameObject>();

	public List<GameObject> garbage = new List<GameObject>();

	public MeshRenderer grass;

	public int level = 1;

	//Spawns a new location
	public override void HandleClick(){
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		int bigSpawnCount = Random.Range (1,16 - level/32);

		for (int i = 0; i < bigSpawnCount; i++) {
			Quaternion q = Quaternion.Euler(new Vector3(Random.Range(-10,10),Random.Range(0,360),Random.Range(-10,10)));
			Vector3 transformPosition = new Vector3 (Random.Range(-40,40),0,Random.Range(-30,10));
			Instantiate (bigSpawns[Random.Range(0,bigSpawns.Count)],transformPosition,q,this.transform);
		}

		int smallSpawnCount = Random.Range (16,64-level/8);

		for (int i = 0; i < smallSpawnCount; i++) {
			Quaternion q = Quaternion.Euler(new Vector3(Random.Range(-10,10),Random.Range(0,360),Random.Range(-10,10)));
			Vector3 transformPosition = new Vector3 (Random.Range(-40,40),0,Random.Range(-30,10));
			Instantiate (smallSpawns[Random.Range(0,smallSpawns.Count)],transformPosition,q,this.transform);
		}

		int garbageSpawnCount = Random.Range (0, level);
		for (int i = 0; i < garbageSpawnCount; i++) {
			Quaternion q = Quaternion.Euler(new Vector3(Random.Range(-10,10),Random.Range(0,360),Random.Range(-10,10)));
			Vector3 transformPosition = new Vector3 (Random.Range(-40,40),0,Random.Range(-30,10));
			Instantiate (garbage[Random.Range(0,garbage.Count)],transformPosition,q,this.transform);
		}

		grass.material.mainTextureOffset = new Vector2(Random.Range (0f, 1f), Random.Range (0f, 1f));
	}

	public void SetLevel( int level){
		this.level = level;
		Color materialColor = grass.GetComponent<MeshRenderer>().sharedMaterial.color;
		grass.GetComponent<MeshRenderer>().sharedMaterial.color = new Color (materialColor.r*0.9f,materialColor.g*0.9f,materialColor.b*0.9f,materialColor.a);
		Debug.Log (grass.GetComponent<MeshRenderer>().sharedMaterial.color);
	
	}

}

