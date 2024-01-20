using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController: MonoBehaviour {
	public static BattleController Instance { get; private set; }

	private void Awake() {
		if (Instance != null) {
			Destroy(Instance.gameObject);
		}
		Instance = this;
	}

	private void OnDestroy() {
		Instance = null;
	}
}