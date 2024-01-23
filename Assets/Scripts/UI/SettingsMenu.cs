using UnityEngine;

public class SettingsMenu: UIBase {
	public void OnButtonClick_GoBack() {
    UIManager.Instance.CloseCurrentMenu();
  }
}