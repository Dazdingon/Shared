using UnityEngine;
using System.Collections;

public class Character_Raycast : MonoBehaviour {
	
	public CharacterStats stats;
	public LayerMask layerMask;
	public float castDistance = 50f;
	
	private bool castPositive;
	private Ray ray;
	private RaycastHit hitInfo;

	// Update is called once per frame
	void Update () {
	
		CastRay();
	}
	
	void CastRay () {
	
		ray.origin = stats.transformInfo.position + new Vector3(0, stats.eyeHeight, 0);
		ray.direction = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0) * Vector3.forward;
		
		castPositive = Physics.Raycast(ray, out hitInfo, castDistance, layerMask);
		
		stats.raycastPositive = castPositive;
		stats.raycastInfo = hitInfo;
	}
}
