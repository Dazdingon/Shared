using UnityEngine;
using System.Collections;

public class Player_Crosshair : MonoBehaviour {

	public PlayerStats player;
	private float interactDistance;

	//Crosshairs
	public GameObject crosshairBreak;
	public GameObject crosshairHand; 
	public GameObject crosshairRadial;

	private ResourceStats resObj;
	private RaycastHit hitInfo;
	private bool castPosetive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		hitInfo = player.characterTarget.raycastInfo;
		castPosetive = player.characterTarget.raycastPosetive;
		interactDistance = player.characterTarget.interactDistance;
		interactionCrosshairHandler(castPosetive, hitInfo);
	
	}

	void interactionCrosshairHandler(bool castPosetive ,RaycastHit hitInfo)
	{
		if(castPosetive && hitInfo.transform)
		{
			resObj = (ResourceStats)hitInfo.transform.GetComponent<ResourceStats>();
			
			if (resObj && hitInfo.distance <= interactDistance)
			{
				

				switch(resObj.inteactionMode)
				{

				case InteractionMode.Breakable:		
					crosshairRadial.renderer.enabled = false;
					crosshairHand.renderer.enabled = false;
					crosshairBreak.renderer.enabled = true;
					break;

				case InteractionMode.Pickupable: 
					crosshairBreak.renderer.enabled = false;
					crosshairRadial.renderer.enabled = false;
					crosshairHand.renderer.enabled = true;
					break;

				default:
					crosshairBreak.renderer.enabled = false;
					crosshairHand.renderer.enabled = false;
					crosshairRadial.renderer.enabled = true;
					break;

				}
			}
			else
			{
				crosshairBreak.renderer.enabled = false;
				crosshairHand.renderer.enabled = false;
				crosshairRadial.renderer.enabled = true;
			}
		}
		else
		{
			crosshairBreak.renderer.enabled = false;
			crosshairHand.renderer.enabled = false;
			crosshairRadial.renderer.enabled = true;
		}
	}
}
