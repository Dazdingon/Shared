using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
	
	public bool emptySpace = false;
	
	void FixedUpdate () {
		
		emptySpace = true;
	}
	
	void OnTriggerEnter() {
	
		emptySpace = false;
	}
	
	void OnTriggerExit() {
	
		emptySpace = false;
	}
	
	void OnTriggerStay() {
	
		emptySpace = false;
	}
}
