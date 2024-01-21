using System;
using UnityEngine;

public class EnemyController: MonoBehaviour {
	public static EnemyController Instance { get; private set; }

	public event Action<float> OnHealthPercentageChange;

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
		if (this.healthPoints == healthPoints) {
			return;
		}
		if (healthPoints < 0 || healthPoints > maxHealthPoints) {
			return;
		}
		this.healthPoints = healthPoints;
		var percentage = (float)healthPoints / (float)maxHealthPoints;
		OnHealthPercentageChange?.Invoke(percentage);
	}

	public int GetMaxHealthPoints() {
		return maxHealthPoints;
	}
}