using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController: MonoBehaviour {
	public static MapController Instance { get; private set; }

	[SerializeField]
	private List<Level> levels;

	[SerializeField]
	private float miniMapMoveSpeed;

	[SerializeField]
	private Transform miniMapCameraTransform;

	[SerializeField]
	private GameObject miniMap;

	[SerializeField]
	private GameObject map;

	private Dictionary<LevelID, Level> levelByID = 
		new Dictionary<LevelID, Level>();

	private LevelID currentLevelID = LevelID.None;

	private void Awake() {
		if (Instance != null) {
			Destroy(Instance.gameObject);
		}
		Instance = this;

		foreach (var level in levels) {
			levelByID.Add(level.id, level);
		}

		miniMap.SetActive(true);
		map.SetActive(false);
	}

	private void OnDestroy() {
		Instance = null;
	}

	public void SetCurrentLevel(LevelID id) {
		if (currentLevelID == id) {
			return;
		}
		var level = levelByID[id];
		var targetPos = level.minimapTransform.position;
		if (currentLevelID != LevelID.None) {
			SceneManager.UnloadSceneAsync(level.sceneName);
			MinimapFocusOn(targetPos);
		} else {
			MinimapFocusOn(targetPos, false);
		}
		SceneManager.LoadSceneAsync(level.sceneName, LoadSceneMode.Additive);
		currentLevelID = id;
		GameManager.Instance.SetCurrentLevelID(id);
	}

	private void MinimapFocusOn(Vector3 targetPos, bool animate = true) {
		var cameraZ = miniMapCameraTransform.position.z;
		targetPos = new Vector3(targetPos.x, targetPos.y, cameraZ);
		if (animate) {
			StartCoroutine(MinimapCameraMoveTowards(targetPos));
		} else {
			miniMapCameraTransform.position = targetPos;
		}
	}

	private IEnumerator MinimapCameraMoveTowards(Vector3 targetPos) {
		while (true) {
			var cameraPos = miniMapCameraTransform.position;
			var distance = Vector2.Distance(cameraPos, targetPos);
			if (Mathf.Approximately(distance, 0f)) {
				yield break;
			} else {
				var speed = Time.deltaTime * miniMapMoveSpeed;
				cameraPos = Vector3.MoveTowards(cameraPos, targetPos, speed);
				miniMapCameraTransform.position = cameraPos;
				yield return null;
			}
		}
	}

	public void OnButtonClick_MapOpen() {
		miniMap.SetActive(false);
		map.SetActive(true);
	}

	public void OnButtonClick_MapClose() {
		miniMap.SetActive(true);
		map.SetActive(false);
	}
}