using UnityEngine;
using System.Collections;

public class PlaceableObject : MonoBehaviour {
	
	public GameObject placementObject;
	public GameObject placementLargePile;
	public GameObject placeableTemplate;
	
	public CollisionDetector detector;

	public void PlaceObject () {

		/*ResourceStats stats = (ResourceStats)placementObject.GetComponent<ResourceStats> ();

		if (stats.stackable) {
			//Number of similar resources required in the vicinity to create largePile
			int stackRequirment = 3;
			int stackCounter = 0;

			//Check for other resource of same type in area
			Collider[] hitColliders = Physics.OverlapSphere(placeableTemplate.transform.position, 5);

			for(int i = 0; i < hitColliders.Length; i++)
			{
				if(hitColliders[i].GetComponent<ResourceStats>())
				{
					ResourceStats statsCollided = (ResourceStats)hitColliders[i].GetComponent<ResourceStats>();

					if(statsCollided.objType == stats.objType)
						stackCounter++;
				}
			}

			if(stackCounter >= stackRequirment)
			{
				
			}

		}
		else*/ if(detector.emptySpace){
			
			Transform newInstance;
				
			newInstance = ((GameObject)(GameObject.Instantiate(placeableTemplate))).transform;
			newInstance.position = placementObject.transform.position;
			newInstance.rotation = placementObject.transform.rotation;
		}
	}	

	private void PlaceStack()
	{
		
	}
	
	// Rendering
	
	public Renderer renderTarget;
	public Color color_Placeable = Color.white;
	public Color color_Unplaceable = Color.white;
	
	private int index;
	
	void Update () {
	
		for (index = 0; index < renderTarget.materials.Length; index++) {
			
			if(detector.emptySpace){
			
				renderTarget.materials[index].color = color_Placeable;
			}
			else {
				
				renderTarget.materials[index].color = color_Unplaceable;
			}
		}
	}
}
