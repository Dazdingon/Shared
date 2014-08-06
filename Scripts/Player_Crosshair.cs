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
	
	private int crosshairIndex;
	
	void Update () {

		hitInfo = player.characterTarget.raycastInfo;
		castPositive = player.characterTarget.raycastPositive;
		interactDistance = player.characterTarget.interactDistance;
		InteractionCrosshairHandler();
	}

	void InteractionCrosshairHandler()
	{
		if(castPositive && hitInfo.transform)
		{
			resObj = (ResourceStats)hitInfo.transform.GetComponent<ResourceStats>();
			
			if (resObj && hitInfo.distance <= interactDistance)
			{

				switch(resObj.inteactionMode)
				{

				case InteractionMode.Pickupable:
					crosshairIndex = 1;
					break;
					
				case InteractionMode.Breakable:
					crosshairIndex = 2;
					break;
					
				default:
					crosshairIndex = 0;
					break;
				}
			}
			else
			{
				crosshairIndex = 0;
			}
		}
		else
		{
			crosshairIndex = 0;
		}

		crosshairRadial.renderer.enabled = (crosshairIndex == 0);
		crosshairHand.renderer.enabled = (crosshairIndex == 1);
		crosshairBreak.renderer.enabled = (crosshairIndex == 2);
	}
}
