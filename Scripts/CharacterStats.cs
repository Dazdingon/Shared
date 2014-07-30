using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	
	// Runtime movement
	public Vector2 viewAngles;// = Vector2(0f, 90f);
	
	public Vector3 lookVector;
	public Vector3 moveVector;
	public Vector3 forceVector;
	
	
	public bool run = false;
	public bool jump = false;
	public bool crouch = false;
	
	// Stats
	public float moveSpeed = 10f;
	public float jumpForce = 10f;
	public float fallSpeed = 10f;

}
