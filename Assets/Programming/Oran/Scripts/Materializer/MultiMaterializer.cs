using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MultiMaterializer : MonoBehaviour {
    private Materializer[] allMaterializers;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
	{
		allMaterializers = this.GetComponentsInChildren<Materializer>();
	}

	[ContextMenu("Materialize")]
	public void Materialize(int fadeDuration) {
		
		foreach(var materializer in allMaterializers){
			materializer.Materialize(fadeDuration);
		}
	}

	[ContextMenu("Dematerialize")]
	public void Dematerialize(int fadeDuration) {
		
		foreach(var materializer in allMaterializers){
			materializer.Dematerialize(fadeDuration);
		}
	}
}

