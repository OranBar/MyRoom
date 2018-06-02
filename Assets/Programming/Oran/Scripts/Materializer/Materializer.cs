using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OranUnityUtils;
using AdvancedCoroutines;
using System;

public class Materializer : MonoBehaviour {

	public string fadePropertyName = "Vector1_5909546F";

	private Renderer myRenderer;
	//private Routine fadeRoutine;

    private void Awake()
	{
		myRenderer = GetComponent<Renderer>();
	}

	#region Inspector
	[ContextMenu("Materialize")]
	private void Insp_Mmaterialize()
	{
		Materialize(2f);
	}
	[ContextMenu("Dematerialize")]
	private void Insp_Dematerialize()
	{
		Dematerialize(2f);
	}
	#endregion

	public void Materialize(float duration){
		this.StartAdvCoroutine(Materialize_Coro(duration));
	}
	
	public void Dematerialize(float duration){
		StartCoroutine(Dematerialize_Coro(duration));
	}

	public IEnumerator Materialize_Coro(float duration)
	{
		var allMaterials = myRenderer.materials;

		float lerpTime = 0f;

		while (lerpTime < 1)
		{
			lerpTime = lerpTime + (Time.deltaTime / duration);
			myRenderer.material.SetFloat(fadePropertyName, lerpTime);
			yield return null;
		}
	}
	
	//Same as above, except for 1-fadeAmount for inverted value.
	public IEnumerator Dematerialize_Coro(float duration)
    {
		var allMaterials = myRenderer.materials;

		float lerpTime = 0f;

		while (lerpTime < 1)
		{
			lerpTime = lerpTime + (Time.deltaTime / duration);
			myRenderer.material.SetFloat(fadePropertyName, 1-lerpTime);
			yield return null;
		}
	}

    private void OnDisable()
	{
		//TODO: Stop the fade coroutine for good measure
		//fadeRoutine?.Stop();
	}
}
