using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandleClick : IHandleClick {

	IHandleClick[] handleClickList;

	void Start(){
		handleClickList = GetComponentsInChildren<IHandleClick>();

		InvokeRepeating ("HandleClick", 0, 1f);
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
}
