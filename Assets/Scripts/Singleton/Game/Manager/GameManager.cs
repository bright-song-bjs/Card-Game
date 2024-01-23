using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager: MonoBehaviour {
	public static GameManager Instance { get; private set; }

	[SerializeField]
	private GameDataSO gameDataSO;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		LoadGameData();
	}

	private void Start() {
		
	}

	private void OnApplicationPause(bool pauseStatus) {
		SaveGameData();
	}

	private void OnApplicationQuit() {
		SaveGameData();
	}

	private void LoadGameData() {
		/*
		var path = Application.persistentDataPath + "/GameData.json";
		if (File.Exists(path)) {
			var json = File.ReadAllText(path);
			JsonUtility.FromJsonOverwrite(json, gameDataSO);
		}
		*/
	}

	private void SaveGameData() {
		/*
		var path = Application.persistentDataPath + "/GameData.json";
		var json = JsonUtility.ToJson(gameDataSO);
		File.WriteAllText(path, json);
		*/
	}

	public LevelID GetCurrentLevelID() {
		return gameDataSO.currentLevelID;
	}

	public void SetCurrentLevelID(LevelID id) {
		gameDataSO.currentLevelID = id;
	}

	public Dictionary<ECardType, int> GetECardCollection() {
		return gameDataSO.eCardsCollection;
	}

	public void GainECard(ECardType type, int count = 1) {
		var collection = gameDataSO.eCardsCollection;
		if (collection.ContainsKey(type)) {
			collection[type] += count;
		} else {
			collection.Add(type, count);
		}
	}
}