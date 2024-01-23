using UnityEngine;

public abstract class UIBase: MonoBehaviour {
	public UIType type;

	public void Show() {
		gameObject.SetActive(true);
	}

	public void Hide() {
		gameObject.SetActive(false);
	}
}