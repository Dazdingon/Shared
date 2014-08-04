using UnityEngine;
using System.Collections;

public class Chacracter_Interact : MonoBehaviour {

	public PlayerStats player;
	private float interactDistance;

	private bool input_use;
	private ResourceObj resObj;
	private RaycastHit hitInfo;
	private bool castPosetive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		castPosetive = player.characterTarget.raycastPosetive;
		hitInfo = player.characterTarget.raycastInfo;
		input_use = player.characterTarget.input_Use;
		interactDistance = player.characterTarget.interactDistance;


		inteactionHandler(castPosetive, hitInfo, input_use);	
	}

	void inteactionHandler(bool castPositive, RaycastHit hitInfo, bool input_use)
	{

		if(castPosetive)
		{
			print ("Cast postitive: " + castPosetive.ToString());
			if(hitInfo.transform.gameObject.GetComponent("ResourceObj"))
			{
				ResourceObj resObj = (ResourceObj)hitInfo.transform.gameObject.GetComponent("ResourceObj");

				if(input_use && hitInfo.distance <= interactDistance)
				{
					switch(resObj.inteactionMode)
					{
					case InteractionMode.Breakable:
						Resource newRes = resObj.getResource();
						Destroy (hitInfo.transform.gameObject);
						print ("Theoretically you now have this new resource: " + newRes.resourceType);
						break;

					case InteractionMode.Pickupable:
						print ("Pick Up");
						break;					
					}
				}
			}
		}
	}
}
