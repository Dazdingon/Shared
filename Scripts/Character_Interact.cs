﻿using UnityEngine;
using System.Collections;

public class Character_Interact : MonoBehaviour {

	public CharacterStats character;
	private float interactDistance;

	private bool input_use;
	private ResourceStats resObj;
	private RaycastHit hitInfo;
	private bool castPosetive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		castPosetive = character.raycastPosetive;
		hitInfo = character.raycastInfo;
		input_use = character.input_Use;
		interactDistance = character.interactDistance;

		inteactionHandler(castPosetive, hitInfo, input_use);	
	}

	void inteactionHandler(bool castPositive, RaycastHit hitInfo, bool input_use)
	{

		if(castPosetive)
		{
			ResourceStats resObj = (ResourceStats)hitInfo.transform.GetComponent<ResourceStats>();

			if(resObj)
			{
				if(input_use && hitInfo.distance <= interactDistance)
				{
					switch(resObj.inteactionMode)
					{
					case InteractionMode.Breakable:
						resObj.breakDown();
						break;

					case InteractionMode.Pickupable:
						resObj.pickUp();
						Destroy (hitInfo.transform.gameObject);
						break;					
					}
				}
			}
		}
	}
}
