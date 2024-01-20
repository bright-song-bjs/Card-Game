using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHUD: UIBase {
	// test-only buttons
	public void OnButtonClick_Settings() {
		UIManager.Instance.OpenPanel(UIType.SettingsMenu);
	}

	public void OnButtonClick_NewLevek() {
		SceneManager.LoadScene("BattleScene");
	}

	public void OnButtonClick_GraphView() {
		UIManager.Instance.OpenPanel(UIType.GraphView);
	}
}