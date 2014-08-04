using UnityEngine;
using System.Collections;

public class ResourceObj : MonoBehaviour {
	
	public string objType = "";
	public string resourceType;	
	public InteractionMode inteactionMode;
	public int resourceQty;
	
	void Start()
	{
		objType = this.gameObject.name;
		
		switch (objType) 
		{
		case "Tree":	
			resourceType = "Wood";
			resourceQty = 5;
			break;
			
		case "Rock":
			resourceType = "Stone";
			resourceQty = 2;
			break;
		}
	}
	
	public Resource getResource()
	{
		Resource res = new Resource (resourceType, resourceQty);
		return res;
	}
}

public enum InteractionMode {Breakable, Harvestable, Pickupable}
