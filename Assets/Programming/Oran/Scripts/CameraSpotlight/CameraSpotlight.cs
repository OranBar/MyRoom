using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using NaughtyAttributes;
using OranUnityUtils;

public class CameraSpotlight : MonoBehaviour {

	public float startDelay;
	public float transitionDuration = 2.2f;

	[Button]
	public void MoveMainCameraToSpot() {
        VRForegroundCanvas.Instance.FadeIn(transitionDuration/3);
		
		this.ExecuteDelayed(
			()=> VRForegroundCanvas.Instance.FadeOut(transitionDuration/3)
		,(transitionDuration/3f)*2f);
		

		Tween.Position(Camera.main.transform.parent, this.transform.position, transitionDuration, startDelay);
		Tween.Rotation(Camera.main.transform.parent, this.transform.rotation, transitionDuration, startDelay);
		

		//Camera.main.transform.position = this.transform.position;
		//Camera.main.transform.rotation = this.transform.rotation;
	}

	public RenderTexture GetCurrentShot(int width = 512, int height = 512){
		RenderTexture result = new RenderTexture (width, height, 16);
		result.name = this.name+"_rt";
        Camera camera1 = GetComponent<Camera>();
        camera1.targetTexture = result;
		camera1.enabled = true;
		this.ExecuteAfterXFrames(1, ()=>camera1.enabled = false);
		return result;
	}
}
