using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController: MonoBehaviour {
	public static EnemyController Instance { get; private set; }

	[SerializeField]
	private int maxHealthPoints;

	private int healthPoints;

	private void Awake() {
		if (Instance != null) {
			Destroy(Instance.gameObject);
		}
		Instance = this;
	}

	private void OnDestroy() {
		Instance = null;
	}

	public int GetHealthPoints() {
		return healthPoints;
	}

	public void SetHealthPoints(int healthPoints) {
		if (healthPoints < 0 || healthPoints > maxHealthPoints) {
			return;
		}
		this.healthPoints = healthPoints;
		var levelHUD = BattleController.Instance.levelHUD;
		var percentage = (float)healthPoints / (float)maxHealthPoints;
		levelHUD.SetEnemyHealthPercentage(percentage);
	}

	public int GetMaxHealthPoints() {
		return maxHealthPoints;
	}
}