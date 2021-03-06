﻿using UnityEngine;
using System.Collections;

public class FPS_MovementInput : MonoBehaviour {
	
	public PlayerStats player;
	
	private CharacterStats stats;
	private Vector3 moveDirection;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Only run if FirstPerson mode
		if(player.controlMode == GameControlMode.FirstPerson){

			// Get stats, return if no characterTarget
			stats = player.characterTarget;	if(!stats)return;
			
			GetInput();
		}
	}
	
	private void GetInput () {
		
		moveDirection.x = Input.GetAxis("Horizontal");
		moveDirection.y = 0;
		moveDirection.z = Input.GetAxis("Vertical");
		
		stats.moveVector = Quaternion.Euler(0, stats.viewAngles.x, 0) * moveDirection;
		//stats.moveVector = stats.transformInfo.TransformDirection(moveDirection);
	}
}
