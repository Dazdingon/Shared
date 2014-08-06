using UnityEngine;
using System.Collections;

public class Player_ResourceDisplay : MonoBehaviour {

	public PlayerStats player;

	public SpriteRenderer renderTarget;
	public Sprite sprite_Wood;
	public Sprite sprite_Stone;
	
	void Update () {
		
		DisplayResource();
	}
	
	private void DisplayResource () {
		
		if(player.characterTarget){
			
			if(player.characterTarget.inventoryResObj == ResourceObjType.Wood){
				
				renderTarget.sprite = sprite_Wood;
			}
			else if (player.characterTarget.inventoryResObj == ResourceObjType.Stone){
				
				renderTarget.sprite = sprite_Stone;
			}
			else{
				
				renderTarget.sprite = null;
			}
		}
		else{

			renderTarget.sprite = null;
		}
	}
}
