using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CardLibrary: MonoBehaviour {
	public static CardLibrary Instance { get; private set; }

	// Later: load prefab as needed instead of loading all in once.
	public Dictionary<CardType, GameObject> contents;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public GameObject Get(CardType cardType) {
		return contents[cardType];
	}
}