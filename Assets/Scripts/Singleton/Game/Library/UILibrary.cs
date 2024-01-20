using System.Collections.Generic;
using UnityEngine;

public class UILibrary: MonoBehaviour {
	public static UILibrary Instance { get; private set; }

	[SerializeField]
	private List<UILibraryItem> items;
	
	private Dictionary<UIType, UIBase> uiBaseByUIType =
		new Dictionary<UIType, UIBase>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var item in items) {
			uiBaseByUIType.Add(item.uiType, item.uiBase);
		}
	}

	public UIBase Get(UIType uiType) {
		return uiBaseByUIType[uiType];
	}
}