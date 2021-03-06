﻿using UnityEngine;
using System.Collections;

public class Character_Interact : MonoBehaviour {

	public CharacterStats character;
	private float interactDistance;

	private bool input_use;
	private ResourceStats resObj;
	private RaycastHit hitInfo;
	private bool castPositive;

	void Update () {

		castPositive = character.raycastPositive;
		hitInfo = character.raycastInfo;
		input_use = character.input_Use;
		interactDistance = character.interactDistance;

		InteactionHandler();	
	}

	private void InteactionHandler()
	{

		if(castPositive)
		{
			ResourceStats resObj = (ResourceStats)hitInfo.transform.GetComponent<ResourceStats>();

			if(resObj)
			{
				if(input_use && hitInfo.distance <= interactDistance)
				{
					switch(resObj.inteactionMode)
					{
					case InteractionMode.Breakable:
						resObj.BreakDown();
						break;

					case InteractionMode.Pickupable:
						if(character.inventoryResObj == ResourceObjType.None){
							
							resObj.PickUp();
							character.inventoryResObj = resObj.objType;
						}
						break;					
					}
				}
			}
		}
	}
}
