using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
/**
	Little tool I made after I noticed my ground isn't y=0.
	Floor was too high.
 */
public class SubtractTransform : MonoBehaviour {

	public Vector3 b = new Vector3(0f, 3.333333f, 0f);

	[Button]
	void Subtract () {
		foreach(Transform child in transform){
			child.position = child.transform.position - b;
		}
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
