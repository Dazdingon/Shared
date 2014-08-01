using UnityEngine;
using System.Collections;

public class Resource{
	
	public string resourceType;
	public GameObject resourceIcon;
	public int qty;
	
	public Resource(string resourceType, int qty)
	{
		this.resourceType = resourceType;
		this.qty = qty;
		resourceIcon = GameObject.Find (resourceType);
		resourceIcon.renderer.enabled = true;
	}
	
	//Methods on how to use wood/stone/ect
}
