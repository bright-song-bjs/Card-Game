using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour, Singleton {
	public static UIManager Instance { get; private set; }

	private Stack<UIBase> panelStack = new Stack<UIBase>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void OpenPanel(UIType uiType, Transform canvasTransform) {
		var panelPrefab = UILibrary.Instance.Get(uiType);
		var panelObject = Instantiate(panelPrefab, canvasTransform, false);
		var panel = panelObject.GetComponent<UIBase>();
		if (!panelStack.IsEmpty) {
			panelStack.Peek().Hide();
		}
		panelStack.Push(panel);
	}

	public void CloseCurrentPanel() {
		if (panelStack.IsEmpty) {
			return;
		}
		var panel = panelStack.Pop();
		Destroy(panel.gameObject);
		if (!panelStack.IsEmpty) {
			panelStack.Peek().Show();
		}
	}
}