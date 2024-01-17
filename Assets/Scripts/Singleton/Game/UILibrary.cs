using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILibrary: MonoBehaviour {
	public static UILibrary Instance { get; private set; }

	// Later: load prefab as needed instead of loading all in once.
	public Dictionary<UIType, GameObject> contents;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public GameObject Get(UIType uiType) {
		return contents[uiType];
	}
}