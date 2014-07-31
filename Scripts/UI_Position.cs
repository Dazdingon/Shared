using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UI_Position : MonoBehaviour {
	
	public enum PinSide {Left, Right}
	public PinSide pinSide;
	public Transform guiObject;
	public bool continuousUpdate = false;
	
	public float orthoSize = 5f;
	public Vector2 offset;
	
	private float screenRatio;
	private float previousWidth;
	private Vector3 position;
	
	
	// Use this for initialization
	void Start () {
	
		ShiftUI();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(continuousUpdate){

			ShiftUI();
		}
	}
	
	private void ShiftUI () {
	
		if(!guiObject)return;
		
		screenRatio = Screen.width;
		screenRatio /= Screen.height;
		
		if(pinSide == PinSide.Left){
		
			screenRatio = -screenRatio;
		}
	
		position = offset;
		position.x += (orthoSize * screenRatio);
		
		if(guiObject.position != position){
			
			guiObject.position = position;
		}
	}
}

