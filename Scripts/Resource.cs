using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour{
	
	public ResourceType resourceType;
	public GameObject resourceIcon;
	public int qty;
	
	public Resource(ResourceType resourceType, int qty)
	{
		this.resourceType = resourceType;
		this.qty = qty;
		resourceIcon = GameObject.Find(resourceType.ToString());
		resourceIcon.renderer.enabled = true;
	}

	public enum ResourceType {Wood, SmallRock}
	
	//Methods on how to use wood/stone/ect
}
