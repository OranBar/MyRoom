using Hover.Core.Utils;
using UnityEngine;

namespace HoverDemos.Common {

	/*================================================================================================*/
	public class DemoAdjustInputSceneCamera : HoverSceneAdjust {

		public string CameraName;
		public string MainSceneCameraName = "MainCamera";
		public bool UseBloom = true;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsReadyToAdjust() {
			return (GameObject.Find(CameraName) != null);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAdjustments() {
			
		}

	}

}
