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

	private void Start() {
		UIManager.Instance.OpenPanel(UIType.LevelHUD);
		var player = PlayerController.Instance;
		if (player != null) {
			player.SetHealthPoints(player.GetMaxHealthPoints());
			player.SetManaPoints(player.GetInitialManaPoints());
		}
		var enemy = EnemyController.Instance;
		if (enemy != null) {
			enemy.SetHealthPoints(enemy.GetMaxHealthPoints());
		}
	}
}