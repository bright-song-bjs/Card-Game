using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
	public static GameManager Instance { get; private set; }

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	/*
	private GameObject FindActiveScreenSpaceOverlayCanvas() {
		var activeScene = SceneManager.GetActiveScene();
		var rootObjects = activeScene.GetRootGameObjects();
		foreach (var obj in rootObjects) {
			if (obj.CompareTag("ScreenSpaceOverlayCanvas")) {
				return obj;
			}
		}
		return null;
	}
	*/
}