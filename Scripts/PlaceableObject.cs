using UnityEngine;
using System.Collections;

public class PlaceableObject : MonoBehaviour {
	
	public GameObject placementObject;
	public GameObject placeableTemplate;
	
	public CollisionDetector detector;

	public void PlaceObject () {
		
		if(detector.emptySpace){
			
			Transform newInstance;
				
			newInstance = ((GameObject)(GameObject.Instantiate(placeableTemplate))).transform;
			newInstance.position = placementObject.transform.position;
			newInstance.rotation = placementObject.transform.rotation;
		}
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
