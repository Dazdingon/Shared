using UnityEngine;
using System.Collections;

public class Character_Raycast : MonoBehaviour {
	
	public CharacterStats stats;
	public LayerMask layerMask;
	public float castDistance = 50f;
	public Vector3 castOffset;
	
	private bool castPosetive;
	private Ray ray;
	private RaycastHit hitInfo;

	// Update is called once per frame
	void Update () {
	
		CastRay();
	}
	
	void CastRay () {
	
		ray.origin = stats.transformInfo.position + castOffset;
		ray.direction = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0) * Vector3.forward;

		
		castPosetive = Physics.Raycast(ray, out hitInfo, castDistance, layerMask);
		
		stats.raycastPosetive = castPosetive;
		stats.raycastInfo = hitInfo;
	}
}
