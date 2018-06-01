using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
