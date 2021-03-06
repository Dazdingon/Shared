﻿using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {
	
	public CharacterStats stats;
	public CharacterController controller;
	
	private Vector3 movement;
	
	void Update () {
		
		if (controller.isGrounded){
		
			ClearForce();
			CheckJump();
		}
		else{
			
			AddWorldForce();
		}
		
		ApplyVector();
	}
	
	void ClearForce () {
		
		stats.forceVector = Vector3.zero;
	}
	
	void AddWorldForce () {
		
		stats.forceVector.y -= stats.fallSpeed * Time.deltaTime;
	}
	
	void CheckJump () {
		
		if(stats.input_Jump){
			
			stats.forceVector.y = stats.jumpForce;
		}
	}
	
	void ApplyVector () {
	
		movement = Vector3.ClampMagnitude(stats.moveVector, 1f);
		movement *= stats.moveSpeed;
		
		if(stats.input_Run && stats.inventoryResObj == ResourceObjType.None){
			
			movement *= stats.runFactor;
		}
	
		movement += stats.forceVector;
		
		// Move the controller
		controller.Move(movement * Time.deltaTime);
	}
}
