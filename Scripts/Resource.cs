using UnityEngine;
using System.Collections;

public class Resource{
	
	public string resourceType;
	public string resourceIconDir;
	public Texture2D resourceIcon;
	public int qty;
	
	public Resource(string resourceType, int qty)
	{
		this.resourceType = resourceType;
		this.qty = qty;
		resourceIconDir = "Icons/" + resourceType;
		resourceIcon = new Texture2D (100, 100);
	}
	
	//Methods on how to use wood/stone/ect
}
