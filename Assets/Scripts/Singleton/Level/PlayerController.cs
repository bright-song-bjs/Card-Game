using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
	public static PlayerController Instance { get; private set; }

	[SerializeField]
	private RectTransform playerCardArea;
	
	[SerializeField]
	private int maxNumberOfHoldingCards;

	[SerializeField]
	private int maxHealthPoints;

	[SerializeField]
	private int initialManaPoints;

	private int healthPoints;

	private int manaPoints;

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
		// test-only
		var library = CardLibrary.Instance;
		var cardCollection = DataManager.Instance.GetPlayerCardCollection();
		foreach (var element in cardCollection) {
			for (int i = 0; i < element.Value; ++i) {
				var cardPrefab = library.Get(element.Key);
				var cardBase = Instantiate(cardPrefab, playerCardArea);
			}
		}
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
		levelHUD.SetPlayerHealthPercentage(percentage);
	}

	public int GetMaxHealthPoints() {
		return maxHealthPoints;
	}

	public int GetManaPoints() {
		return manaPoints;
	}

	public void SetManaPoints(int manaPoints) {
		if (manaPoints < 0) {
			return;
		}
		this.manaPoints = manaPoints;
		var levelHUD = BattleController.Instance.levelHUD;
		levelHUD.SetPlayerManaPoints(manaPoints);
	}

	public int GetInitialManaPoints() {
		return initialManaPoints;
	}
}