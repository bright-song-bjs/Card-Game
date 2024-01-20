using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour {
	public static UIManager Instance { get; private set; }

	public RectTransform mainCanvasPrefab;

	private Stack<UIBase> uiStack = new Stack<UIBase>();

	private RectTransform mainCanvas;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
			mainCanvas = Instantiate(mainCanvasPrefab);
			DontDestroyOnLoad(mainCanvas);
		} else {
			Destroy(gameObject);
		}
	}

	public UIBase OpenPanelReturningInstance(
		UIType uiType, 
		bool hideCurrent = true
	) {
		var uiPrefab = UILibrary.Instance.Get(uiType);
		var uiBase = Instantiate(uiPrefab, mainCanvas, false);
		if (!uiStack.IsEmpty && hideCurrent) {
			uiStack.Peek().Hide();
		}
		uiStack.Push(uiBase);
		uiBase.Show();
		return uiBase;
	}

	public void OpenPanel(UIType uiType, bool hideCurrent = true) {
		UIBase uiBase;
		uiBase = OpenPanelReturningInstance(uiType, hideCurrent);
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