using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	public void LoadScene (int buildIndex) {
		SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
	}
}
