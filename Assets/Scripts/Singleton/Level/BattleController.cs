using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController: MonoBehaviour, Singleton {
	public static BattleController Instance { get; private set; }

	private BattleStateMachine battleStateMachine;

	private void Awake() {
		if (Instance != null) {
			Destroy(Instance.gameObject);
		}
		Instance = this;

		battleStateMachine = new BattleStateMachine();
	}

	private void OnDestroy() {
		Instance = null;
	}
}