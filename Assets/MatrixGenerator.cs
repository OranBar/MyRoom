using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class MatrixGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	[BoxGroup("Generation Parameters")]
	public float cubeLength = 10;
	[BoxGroup("Generation Parameters")]
	public int densityPerSide = 10;  
	[BoxGroup("Generation Parameters")]
	public float padding = 1;
	[BoxGroup("Generation Parameters")]
	public GameObject zLinePrefab, yLinePrefab, xLinePrefab;
	// [BoxGroup("Generation Parameters")]
	// public AnimationCurve distanceDecay;

	[Button]
	void GenerateMatrix () {


		float halfDensityPerSide = densityPerSide * 0.5f;
		Transform linesParent = new GameObject("LinesParent").transform;

		for(int y=0; y<densityPerSide;y++){
			for(int i=0;i < densityPerSide;i++){

				//Let's start with the X axis			
				//The subtraction is used to center the result.
				float centeredIndex = (i-halfDensityPerSide);
				float centeredY = (y-halfDensityPerSide);
				float distance = Mathf.Abs(y)+Mathf.Abs(i);
				var multiplier = padding;// * distanceDecay.Evaluate(distance);
				// float xCoord = centeredIndex * padding * distanceDecay.Evaluate(distance);
				// float yCoord = centeredY * padding * distanceDecay.Evaluate(distance);
				var newXLineGo = Instantiate(xLinePrefab, new Vector3(centeredIndex,centeredY,0f)*multiplier, Quaternion.identity, linesParent);
				//Stretch
				var tmp = newXLineGo.transform.localScale;
				tmp.z *= cubeLength;
				newXLineGo.transform.localScale = tmp;

				//Same with other z axis.
				var newZLineGo = Instantiate(zLinePrefab, new Vector3(0f,centeredY,centeredIndex)*multiplier, Quaternion.identity, linesParent);
				//Stretch
				var tmp3 = newZLineGo.transform.localScale;
				tmp3.x *= cubeLength;
				newZLineGo.transform.localScale = tmp3;
			
				// var newYLineGo = Instantiate(yLinePrefab, new Vector3(coordinate,0f,0f), Quaternion.identity, linesParent);
				// //Stretch
				// var tmp2 = newYLineGo.transform.localScale;
				// tmp2.y *= cubeLength;
				// newYLineGo.transform.localScale = tmp2;	
			}
		}

		//This is for the Y
		for(int x=0; x<densityPerSide;x++){
			for(int z=0;z < densityPerSide;z++){
				float distance = Mathf.Abs(x)+Mathf.Abs(z);
				var multiplier = padding;// * distanceDecay.Evaluate(distance);
                float xCoord = (x - halfDensityPerSide) *multiplier;
				float zCoord = (z - halfDensityPerSide) *multiplier;
                var newZLineGo = Instantiate(yLinePrefab, new Vector3(xCoord, 0f,zCoord), Quaternion.identity, linesParent);
				//Stretch
				var tmp3 = newZLineGo.transform.localScale;
				tmp3.y *= cubeLength;
				newZLineGo.transform.localScale = tmp3;
			}
		}

		
	}
}
