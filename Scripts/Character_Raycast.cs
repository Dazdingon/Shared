using UnityEngine;
using System.Collections;

public class Character_Raycast : MonoBehaviour {
	
	public CharacterStats stats;
	public LayerMask layerMask;
	public float castDistance = 50f;
	
	private bool castPosetive;
	private Ray ray;
	private RaycastHit hitInfo;

	void Start()
	{

	}

	// Update is called once per frame
	void Update () {
	
		CastRay();			

	}
	
	void CastRay () {
	
		ray.origin = stats.transformInfo.position + new Vector3(0, stats.eyeHeight, 0);
		ray.direction = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0) * Vector3.forward;

		
		castPosetive = Physics.Raycast(ray, out hitInfo, castDistance, layerMask);
		
		stats.raycastPosetive = castPosetive;
		stats.raycastInfo = hitInfo;
	}
}
