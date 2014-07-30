using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	
	// Components
	public Transform transformInfo;
	
	// Runtime movement
	public Vector2 viewAngles;
	public Vector3 moveVector;
	public Vector3 forceVector;
	
	public bool running = false;
	public bool jumping = false;
	public bool crouching = false;
	
	// Runtime rycastInfo
	public RaycastHit raycastInfo;
	public bool raycastPosetive = false;
	
	// Stats
	public float moveSpeed = 10f;
	public float runFactor = 2f;
	public float jumpForce = 10f;
	public float fallSpeed = 10f;
}
