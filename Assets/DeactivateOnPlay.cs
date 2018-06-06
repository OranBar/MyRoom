using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnPlay : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
