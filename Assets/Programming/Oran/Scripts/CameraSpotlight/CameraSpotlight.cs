﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using NaughtyAttributes;
using OranUnityUtils;

public class CameraSpotlight : MonoBehaviour {

	public float startDelay;
	public float transitionDuration = 2.2f;

	public OBEvent onTransitionFinish;

	[Button]
	public void MoveMainCameraToSpot() {
        VRForegroundCanvas.Instance.FadeIn(transitionDuration/3);
		var prevNearClipPlane_value = Camera.main.nearClipPlane;
		Camera.main.nearClipPlane = 0.001f;
		
		//Fade out black canvas
		Camera.main.gameObject.ExecuteDelayed(
			()=> {
				VRForegroundCanvas.Instance.FadeOut(transitionDuration/3);
			}
		,(transitionDuration/3f)*2.5f);

		//Fix clipping plane. This will probably make the black canvas disappear, so we do it at the end.
		Camera.main.gameObject.ExecuteDelayed((	)=> {
				Camera.main.nearClipPlane = prevNearClipPlane_value;
			}
		,transitionDuration);
		
		Tween.Position(Camera.main.transform.parent, this.transform.position, transitionDuration, startDelay);
		Tween.Rotation(Camera.main.transform.parent, this.transform.rotation, transitionDuration, startDelay, completeCallback: ()=>onTransitionFinish.Invoke() );
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
