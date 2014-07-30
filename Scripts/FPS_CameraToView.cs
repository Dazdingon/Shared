using UnityEngine;
using System.Collections;

public class FPS_CameraToView : MonoBehaviour {
	
	public CharacterStats stats;
	public Transform cameraTransform;
	
	// Update is called once per frame
	void Update () {
	
		RotateCamera();
	}
	
	// RotateCamera
	void RotateCamera () {
	
		cameraTransform.rotation = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0);
	}
}
