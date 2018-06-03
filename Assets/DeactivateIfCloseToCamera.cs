using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using UnityEngine;

public class DeactivateIfCloseToCamera : MonoBehaviour {

	// public GameObject target;
	public float thershold;
    private Routine myCoro;

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
			if(distanceToCamera <= thershold){
				if(this.gameObject.activeSelf){
					this.gameObject.SetActive(false);
				}
			} else{
				if(this.gameObject.activeSelf == false){
					this.gameObject.SetActive(true);
				}
			}
			// yield return null;
			yield return new Wait(Wait.WaitType.ForEndOfFrame);
		}
	}
}
