using UnityEngine;
using System.Collections;

public class PlaceableObject : MonoBehaviour {
	
	public GameObject placementObject;
	public GameObject placeableTemplate;
	
	public Renderer renderTarget;
	public Color color_Placeable = Color.white;
	public Color color_Unplaceable = Color.white;
	
	public bool isPlaceable = false;
	

	public void PlaceObject () {
		
		if(isPlaceable){
			
			Transform newInstance;
				
			newInstance = ((GameObject)(GameObject.Instantiate(placeableTemplate))).transform;
			newInstance.position = placementObject.transform.position;
			newInstance.rotation = placementObject.transform.rotation;
		}
	}
	

	void Update () {
	
		if(isPlaceable){
			
			renderTarget.material.color = color_Placeable;
		}
		else {
			
			renderTarget.material.color = color_Unplaceable;
		}
		//this.collider.rigidbody.WakeUp();
	}
	
	void FixedUpdate () {
		
		isPlaceable = true;
	}
	
	//void OnTriggerStay(Collider other) {
	void OnTriggerStay() {
	
		isPlaceable = false;
	}
}
