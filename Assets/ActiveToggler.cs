using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inspector/ActiveToggler")]
public class ActiveToggler : MonoBehaviour {

	public void ToggleActiveSelf(){
		this.gameObject.SetActive(!this.gameObject.activeSelf);
	}
}
