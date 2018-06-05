using System.Collections;
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
	public void MoveMainCameraToSpot()
    {
		MoveMainCameraToSpot(transitionDuration);
	}

	public void MoveMainCameraToSpot(float animDduration)
    {

        Tween.Position(Camera.main.transform.parent, this.transform.position, animDduration, startDelay);
        Tween.Rotation(Camera.main.transform.parent, this.transform.rotation, animDduration, startDelay, completeCallback: () => onTransitionFinish.Invoke());
        FadeInAndOut_BlackCanvas(animDduration);

    }

    private void FadeInAndOut_BlackCanvas(float animDduration)
    {
        //Make sure the canvas is shown
        var prevNearClipPlane_value = Camera.main.nearClipPlane;
        Camera.main.nearClipPlane = 0.001f;

        VRForegroundCanvas.Instance.FadeIn(animDduration / 3);

        //Fade out black canvas
        Camera.main.gameObject.ExecuteDelayed(
            () =>
            {
                VRForegroundCanvas.Instance.FadeOut(animDduration / 3);
            }
        , (animDduration / 3f) * 2.5f);

        //Fix clipping plane. This will probably make the black canvas disappear, so we do it at the end.
        Camera.main.gameObject.ExecuteDelayed(() =>
        {
            Camera.main.nearClipPlane = prevNearClipPlane_value;
        }
        , animDduration);
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
