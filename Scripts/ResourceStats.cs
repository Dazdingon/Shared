using UnityEngine;
using System.Collections;

public class ResourceStats : MonoBehaviour {
	
	public ResourceObjType objType;
	public GameObject resourceReplacement;	
	public InteractionMode inteactionMode;
	public SpriteRenderer resourceIcon;

	public void breakDown()
	{
		if(resourceReplacement)
		GameObject.Instantiate (resourceReplacement, this.gameObject.transform.position, this.gameObject.transform.rotation);
		GameObject.Destroy (this.gameObject);
	}

	public void pickUp()
	{
		print ("Theortically you now have this resource: " + objType.ToString ());
		//resourceIcon.enabled = true;
		GameObject.Destroy (this.gameObject);
	}

}

public enum InteractionMode {Breakable, Harvestable, Pickupable}

public enum ResourceObjType{None, LargeTree, LargeRock, SmallRock}
