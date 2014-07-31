using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	
	// Components
	public Transform transformInfo;
	
//		-	Stats	-
	
	// Stats - Combat
	public CappedStat health = new CappedStat(10f);
	
	// Stats - Movement
	public float moveSpeed = 10f;
	public float runFactor = 2f;
	public float jumpForce = 10f;
	public float fallSpeed = 10f;
	
//		-	Runtime	-
	
	// Runtime movement
	[HideInInspector] public Vector2 viewAngles;
	[HideInInspector] public Vector3 moveVector;
	[HideInInspector] public Vector3 forceVector;
	
	[HideInInspector] public bool running = false;
	[HideInInspector] public bool jumping = false;
	[HideInInspector] public bool crouching = false;
	
	// Runtime rycastInfo
	public RaycastHit raycastInfo;
	public bool raycastPosetive = false;
}
