using UnityEngine;
using System.Collections;

public class Character_Raycast : MonoBehaviour {
	
	public CharacterStats stats;
	public LayerMask layerMask;
	public float castDistance = 50f;
	
	private bool castPosetive;
	private Ray ray;
	private RaycastHit hitInfo;

	public KeyCode interactKey = KeyCode.E;
	private GameObject crosshairHand; 
	private GameObject crosshairRadial;
	private float interactDistance = 3f;

	void Start()
	{
		crosshairHand = GameObject.Find("Crosshair_Hand");
		crosshairRadial = GameObject.Find("Crosshair_Radial");
	}

	// Update is called once per frame
	void Update () {
	
		CastRay();
		interactionHandler(castPosetive, hitInfo, crosshairHand, crosshairRadial);
		

	}
	
	void CastRay () {
	
		ray.origin = stats.transformInfo.position + new Vector3(0, stats.eyeHeight, 0);
		ray.direction = Quaternion.Euler(stats.viewAngles.y, stats.viewAngles.x, 0) * Vector3.forward;

		
		castPosetive = Physics.Raycast(ray, out hitInfo, castDistance, layerMask);
		
		stats.raycastPosetive = castPosetive;
		stats.raycastInfo = hitInfo;
	}

	void interactionHandler(bool castPosetive ,RaycastHit hitInfo, GameObject crosshairA, GameObject crosshairB)
	{
		if(!castPosetive)
		{
			crosshairA.renderer.enabled = false;
			crosshairB.renderer.enabled = true;
		}
		else if (hitInfo.transform.gameObject.GetComponent ("ResourceObj") && hitInfo.distance < interactDistance)
		{
			crosshairA.renderer.enabled = true;
			crosshairB.renderer.enabled = false;

			if(Input.GetKeyDown(interactKey))
			{
				ResourceObj resObject = (ResourceObj)hitInfo.transform.gameObject.GetComponent("ResourceObj");
				Resource newRes = resObject.getResource();
				Destroy (hitInfo.transform.gameObject);
				print ("Theoretically you now have this new resource: " + newRes.resourceType);
			}
		}
		else
		{
			crosshairA.renderer.enabled = false;
			crosshairB.renderer.enabled = true;
		}
	}
}
