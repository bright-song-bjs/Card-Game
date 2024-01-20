using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHUD: UIBase {
	// test-only buttons
	public void OnButtonClick_Pause() {

	}

	public void OnButtonClick_Leave() {
		UIManager.Instance.CloseCurrentPanel();
		SceneManager.LoadScene("MainScene");
	}

	public void OnButtonClick_GraphView() {
		UIManager.Instance.OpenPanel(UIType.GraphView);
	}
}