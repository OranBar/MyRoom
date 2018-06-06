using System.Collections;
using System.Collections.Generic;
using Hover.Core.Items.Types;
using Hover.RendererModules.Alpha;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHoverColor : MonoBehaviour {

	private HoverAlphaMeshUpdater hoverMesh;
	[ColorUsage(true, true, 0, 1000, 0, 1000)]
	public Color targetColor;

	public void Awake(){
		hoverMesh = GetComponent<HoverAlphaMeshUpdater>();
		GetComponentInParent<HoverItemDataSelector>().OnSelected += _ => ChangeColorToTarget();
	}

	public void ChangeColorToTarget(){
		hoverMesh.StandardColor *= targetColor;
	}
	
	
}
