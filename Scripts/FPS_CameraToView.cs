using UnityEngine;
using System.Collections;

public class FPS_CameraToView : MonoBehaviour {
	
	public PlayerStats player;
	public Transform cameraTransform;
	
	private CharacterStats stats;
	private Vector3 cameraOffset;
	
	// Update is called once per frame
	void Update () {
	
		// Only run if FirstPerson mode
		if(player.controlMode == GameControlMode.FirstPerson){

			// Get stats, return if no characterTarget
			stats = player.characterTarget;	if(!stats)return;
			
			RotateCamera();
		}
	}
	
	// RotateCamera
	void RotateCamera () {
	
		cameraOffset = new Vector3(0, stats.eyeHeight, 0);
		cameraTransform.rotation = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0);
		cameraTransform.position = stats.transformInfo.position + cameraOffset;
	}
}
