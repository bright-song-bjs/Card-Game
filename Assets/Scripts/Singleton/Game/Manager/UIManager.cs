using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour, Singleton {
	public static UIManager Instance { get; private set; }

	public RectTransform mainCanvas;

	private Stack<UIBase> uiStack = new Stack<UIBase>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void OpenPanel(UIType uiType, bool hideCurrent = true) {
		var uiPrefab = UILibrary.Instance.Get(uiType);
		var uiObject = Instantiate(uiPrefab, mainCanvas, false);
		var uiBase = uiObject.GetComponent<UIBase>();
		if (!uiStack.IsEmpty && hideCurrent) {
			uiStack.Peek().Hide();
		}
		uiStack.Push(uiBase);
		uiBase.Show();
	}

	public void CloseCurrentPanel() {
		if (uiStack.IsEmpty) {
			return;
		}
		var uiBase = uiStack.Pop();
		Destroy(uiBase.gameObject);
		if (!uiStack.IsEmpty) {
			uiStack.Peek().Show();
		}
	}
}