using System.Collections;
using System.Collections.Generic;
using Hover.RendererModules.Alpha;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHoverColor : MonoBehaviour {

	private HoverAlphaMeshUpdater myImage;
	[ColorUsage(true, true, 0, 1000, 0, 1000)]
	public Color targetColor;

	public void Awake(){
		myImage = GetComponent<HoverAlphaMeshUpdater>();
	}

	public void ChangeColorToTarget(){
		myImage.StandardColor = targetColor;
	}
	
	
}
