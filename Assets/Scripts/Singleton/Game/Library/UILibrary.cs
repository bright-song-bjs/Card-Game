using System.Collections.Generic;
using UnityEngine;

public class UILibrary: MonoBehaviour {
	public static UILibrary Instance { get; private set; }

	[SerializeField]
	private List<UIBase> uiBasePrefabs;
	
	private Dictionary<UIType, UIBase> uiBasePrefabByType =
		new Dictionary<UIType, UIBase>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var prefab in uiBasePrefabs) {
			uiBasePrefabByType.Add(prefab.type, prefab);
		}
	}

	public UIBase GetUIBasePrefab(UIType type) {
		return uiBasePrefabByType[type];
	}
}