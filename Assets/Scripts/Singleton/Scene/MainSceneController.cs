using UnityEngine;

public class MainSceneController: MonoBehaviour {
	public static MainSceneController Instance { get; private set; }

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
		var map = MapController.Instance;
		if (map != null) {
			map.SetCurrentLevel(GameManager.Instance.GetCurrentLevelID());
		}
	}

	public void OnButtonClick_MyCard() {
		UIManager.Instance.OpenMenu(UIType.CardInventory);
	}

	public void OnButtonClick_Settings() {
		UIManager.Instance.OpenMenu(UIType.SettingsMenu);
	}
}