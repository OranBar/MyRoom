using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;

public class VRForegroundCanvas : Singleton<VRForegroundCanvas> {
	
    private RawImage target;
	// Update is called once per frame

    protected override void InitTon()
    {
		target = GetComponent<RawImage>();
    }

	public void FadeOut (float time) {
		Color transparent = Color.white;
		transparent.a = 0f;
        Tween.Color(target, transparent, time, 0);
	}

	public void FadeIn (float time) {
		Tween.Color(target, Color.white, time, 0);
	}

}
