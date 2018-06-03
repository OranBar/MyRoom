using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour {

	public OBEvent onStart;

	// Use this for initialization
	void Start () {
		onStart.Invoke();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
