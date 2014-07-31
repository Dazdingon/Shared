using UnityEngine;
using UnityEditor;

[System.Serializable]
public class CappedStat {
	
	public float current;
	public float maximum;
	
	public CappedStat (float initialValue) {
		
		maximum = initialValue;
		current = initialValue;
	}
	
	public void Add (float addValue) {
		
		current += addValue;
		Clamp();
	}
	
	public void Fill () {
		
		current = maximum;
	}
	
	public void Clamp () {
		
		current = Mathf.Clamp(current, 0f, maximum);
	}
}