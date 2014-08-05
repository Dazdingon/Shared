using UnityEngine;
using System.Collections;

public class CharacterTest_Dwarf : MonoBehaviour {

	public CharacterStats stats;
	
	public Vector3[] targetPoints;
	
	private Vector3 direction;
	private int targetIndex;
	
	void Update () {
	
		if(targetPoints.Length > 0){
			
			RunToPoint();
		}
	}
	
	private void RunToPoint () {
	
		direction = targetPoints[targetIndex] - stats.transformInfo.position;
		direction.y = 0f;
		
		stats.moveVector = direction;
		
		if(direction.sqrMagnitude < 1f){
			
			targetIndex = (targetIndex + 1) % targetPoints.Length;
		}
	}
}
