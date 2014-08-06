using UnityEngine;
using System.Collections;

public class Character_ObjectPlacing : MonoBehaviour {
	
	public CharacterStats stats;
	
	public PlaceableObject[] placeableObjects;
	
	public PlaceableObject placeableInstance;
	
	private Transform objectInstance;
	private float angleOffset = 90f;
	
	void Start () {
	
	}

	void Update () {
	
		if(!objectInstance){
			
			objectInstance = ((GameObject)(GameObject.Instantiate(placeableObjects[0].placementObject))).transform;
			placeableInstance = objectInstance.GetComponentInChildren<PlaceableObject>();
		}
		
		if(stats.raycastPosetive){
			
			if(stats.raycastInfo.distance < stats.interactDistance && stats.raycastInfo.point.y < 0.1f){

				ShowPalceable();
			}
			else{
				
				HidePalceable();
			}
		}
		else{
			
			HidePalceable();
		}
		
		angleOffset += Input.GetAxis("Mouse ScrollWheel") * 90f;
	}
	
	void ShowPalceable () {
	
		objectInstance.position = stats.raycastInfo.point;
		objectInstance.rotation = Quaternion.Euler(0, stats.viewAngles.x + angleOffset, 0);
		
		if(stats.input_Use){
			
			stats.input_Use = false;
			placeableInstance.PlaceObject();
		}
	}
	
	void HidePalceable () {
	
		objectInstance.position = Vector3.down * 5f;
	}
}
