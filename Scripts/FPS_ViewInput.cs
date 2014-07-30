using UnityEngine;
using System.Collections;

public class FPS_ViewInput : MonoBehaviour {
	
	public CharacterStats stats;
	public Vector2 inputSpeed = Vector2.one;
	
	private Vector2 lookInput;
	
	void Update () {
	
		LockScreen();
		GetInput();
		SetViewAngels();
	}
	
	// GetInput
	void GetInput () {
	
		lookInput.x = Input.GetAxis("Mouse X");
		lookInput.y = Input.GetAxis("Mouse Y");
	}
	
	// SetViewAngels
	void SetViewAngels () {
	
		stats.viewAngles += Vector2.Scale(lookInput, inputSpeed);

		// Clamp vertical view
		stats.viewAngles.y = Mathf.Clamp(stats.viewAngles.y, -90, 90);
	}
	
	// Hide mouse when screen is clicked
	void LockScreen () {
	
		if(Input.GetKeyDown(KeyCode.Escape)){
	
			Screen.lockCursor = false;
		}
		else if(Input.GetMouseButtonDown(0) || Input.anyKey){
		
			Screen.lockCursor = true;
		}
	}
}
