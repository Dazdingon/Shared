using UnityEngine;
using System.Collections;

public class FPS_ActionInput : MonoBehaviour {
	
	public PlayerStats player;
	
	private CharacterStats stats;
	
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

		stats.jumping = Input.GetKey(KeyCode.Space);
		
		stats.running = (
		
			Input.GetKey(KeyCode.LeftShift) ||
			Input.GetKey(KeyCode.RightShift)
		);
		
		stats.crouching = (
	
			Input.GetKey(KeyCode.LeftControl) ||
			Input.GetKey(KeyCode.RightControl) ||
			Input.GetKey(KeyCode.C)
		);
	}
}
