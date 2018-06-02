using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OranUnityUtils;
using AdvancedCoroutines;
using System;

public class Materializer : MonoBehaviour {
    private Renderer myRenderer;

	private Routine fadeRoutine;

    private void Awake()
	{
		myRenderer = GetComponent<Renderer>();
	}

	[ContextMenu("Materialize")]
	public void Materialize(int duration){
		this.StartAdvCoroutine(Materialize_Coro(duration));
	}

	[ContextMenu("Dematerialize")]
	public void Dematerialize(int duration){
		this.StartAdvCoroutine(Dematerialize_Coro(duration));
	}

	public IEnumerator Materialize_Coro(int duration){		
		var allMaterials = myRenderer.materials;
		
		float lerpTime = 0f;

		foreach(Material material in allMaterials){
			lerpTime = lerpTime + (Time.deltaTime / duration);
			float fadeAmount = lerpTime;
			material.SetFloat("FadeAmount", fadeAmount);
			yield return new Wait(Wait.WaitType.ForEndOfFrame);
		}
	}

	//Same as above, except for 1-fadeAmount for inverted value.
    public IEnumerator Dematerialize_Coro(int duration)
    {
        var allMaterials = myRenderer.materials;
		
		float lerpTime = 0f;

		foreach(Material material in allMaterials){
			lerpTime = lerpTime + (Time.deltaTime / duration);
			float fadeAmount = lerpTime;
			material.SetFloat("FadeAmount", 1-fadeAmount);
			yield return new Wait(Wait.WaitType.ForEndOfFrame);
		}
    }

    private void OnDisable()
	{
		//For good measure
		fadeRoutine.Pause();
	}
}
