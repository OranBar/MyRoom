using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyWorldPosition : MonoBehaviour {

	public bool copyPosition = true, copyRotation= true;

	public Transform targetToCopy;

	[NaughtyAttributes.Button]
	void Do() {
		if(copyPosition){
			this.transform.position = targetToCopy.position;
		}
		if(copyRotation){
		this.transform.rotation = targetToCopy.rotation;
		}
		DestroyImmediate(this);
	}
	
}
