using UnityEngine;
using System.Collections;

public class ResourceStats : MonoBehaviour {
	
	public ResourceObjType objType;
	public GameObject resourceReplacement;	
	public InteractionMode inteactionMode;
	//public SpriteRenderer resourceIcon;

	public void BreakDown()
	{

		GameObject.Instantiate (resourceReplacement, this.gameObject.transform.position, this.gameObject.transform.rotation);
		GameObject.Destroy (this.gameObject);
	}

	public void PickUp()
	{

		GameObject.Destroy (this.gameObject);
	}
}

public enum InteractionMode {Uninteractable, Pickupable, Breakable, Harvestable}

public enum ResourceObjType{None, Wood, Stone}
