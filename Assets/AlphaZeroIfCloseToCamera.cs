using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OranUnityUtils;
using AdvancedCoroutines;

[RequireComponent(typeof(CanvasGroup))]
public class AlphaZeroIfCloseToCamera : MonoBehaviour {
// public GameObject target;
	public float thershold;
    private Routine myCoro;
	private CanvasGroup canvasGroup;

	private void Awake()
	{
		canvasGroup = this.GetComponent<CanvasGroup>();
	}

	private void Start()
	{
		StartPolling();
	}

	[ContextMenu("Start")]
    void StartPolling()
	{
		myCoro = this.StartAdvCoroutine_Standalone(ActivateDeactivateCoro());
	}

	[ContextMenu("Stop")]
	void StopPolling(){
		myCoro.Stop();
	}

    private IEnumerator ActivateDeactivateCoro() {
		while(true){
			var distanceToCamera = Vector3.Distance(this.transform.position, Camera.main.transform.position);
            
            if (distanceToCamera <= thershold){
				if(canvasGroup.alpha != 0f){
                    canvasGroup.alpha = 0f;
				}
			} else{
				if(canvasGroup.alpha != 1f){
                    canvasGroup.alpha = 1f;
				}
			}
			// yield return null;
			yield return new Wait(Wait.WaitType.ForEndOfFrame);
		}
	}
}