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
	private bool castPositive;

	void Update () {

		hitInfo = player.characterTarget.raycastInfo;
		castPositive = player.characterTarget.raycastPositive;
		interactDistance = player.characterTarget.interactDistance;
		interactionCrosshairHandler(castPositive, hitInfo);
	
	}

	void interactionCrosshairHandler(bool castPositive ,RaycastHit hitInfo)
	{
		if(castPositive && hitInfo.transform)
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
