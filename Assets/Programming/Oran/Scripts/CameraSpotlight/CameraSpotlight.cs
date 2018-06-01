using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using NaughtyAttributes;

public class CameraSpotlight : MonoBehaviour {

	public float startDelay;
	public float transitionDuration = 2.2f;

	[Button]
	public void MoveMainCameraToSpot() {
        Tween.Position(Camera.main.transform.parent, this.transform.position, transitionDuration, startDelay);
		Tween.Rotation(Camera.main.transform.parent, this.transform.rotation, transitionDuration, startDelay);
		//Camera.main.transform.position = this.transform.position;
		//Camera.main.transform.rotation = this.transform.rotation;
	}
}
