using UnityEngine;
using System.Collections;

public class ChildrenDetacher : MonoBehaviour {

	public GameObject parentObject;

	void Start()
	{
		parentObject.transform.DetachChildren ();
		Destroy (parentObject);
	}
}
