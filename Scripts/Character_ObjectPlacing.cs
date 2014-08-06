using UnityEngine;
using System.Collections;

public class Character_ObjectPlacing : MonoBehaviour {
	
	public CharacterStats stats;
	
	public GameObject placeable_WoodPile;
	public GameObject placeable_StonePile;
	
	private Transform displayObject;
	
	private float angleOffset = 90f;
	
	private bool isPlaceable;
	
	void Update () {
	
		if(!displayObject){
			
			CreateDisplayObject();
		}
		
		if(stats.raycastPositive && stats.inventoryResObj != ResourceObjType.None){
			
			if(stats.raycastInfo.distance < stats.interactDistance && stats.raycastInfo.point.y < 0.1f){

				isPlaceable = true;
			}
			else{
				
				isPlaceable = false;
			}
		}
		else{
			
			isPlaceable = false;
		}
		
		angleOffset += Input.GetAxis("Mouse ScrollWheel") * 90f;
		
	if(!displayObject)return;
		
		if(isPlaceable){
			
			ShowDisplayObject();
			
			if(stats.input_Use){
			
				PlaceObject();
			}
		}
		else{
			
			HideDisplayObject();
		}
	}
	
	private void PlaceObject () {
		
		PlaceableObject componentPlaceable;
		
		componentPlaceable = displayObject.GetComponentInChildren<PlaceableObject>();
		stats.input_Use = false;
	
		if(componentPlaceable.detector.emptySpace){
			
			componentPlaceable.PlaceObject();
			stats.inventoryResObj = ResourceObjType.None;
			RemoveDisplayObject();
		}
	}
	
	private void CreateDisplayObject () {
	
		GameObject prefabTemplate = null;
		
		if(stats.inventoryResObj == ResourceObjType.Wood){
				
			prefabTemplate = placeable_WoodPile;
		}
		else if(stats.inventoryResObj == ResourceObjType.Stone){
			
			prefabTemplate = placeable_StonePile;
		}
		
		if(prefabTemplate){
			
			displayObject = ((GameObject)GameObject.Instantiate(prefabTemplate)).transform;
		}
	}
	private void RemoveDisplayObject () {
	
		GameObject.Destroy(displayObject.gameObject);
	}
	
	private void ShowDisplayObject () {
	
		displayObject.position = stats.raycastInfo.point;
		displayObject.rotation = Quaternion.Euler(0, stats.viewAngles.x + angleOffset, 0);
	}
	
	private void HideDisplayObject () {
	
		displayObject.position = Vector3.down * 5f;
	}
}