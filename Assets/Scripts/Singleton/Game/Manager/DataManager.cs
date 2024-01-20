using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager: MonoBehaviour {
	public static DataManager Instance { get; private set; }

	private static String GameDataJsonPath {
		get => Application.persistentDataPath + "/GameData.json";
	}

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

	// get data
	public Dictionary<CardType, int> GetPlayerCardCollection() {
		return gameDataSO.playerCardCollection;
	}

	public List<int> GetPlayerUnlockedVertices() {
		return gameDataSO.playerUnlockedVertices;
	}
	// end get data

	// set data
	public void AddPlayerUnlockedVertex(int i) {
		gameDataSO.playerUnlockedVertices.Add(i);
	}

	public void AddPlayerCard(CardType cardType, int count = 1) {
		gameDataSO.playerCardCollection[cardType] += count;
	}
	// end set data

	private void OnApplicationPause(bool pauseStatus) {
		SaveGameData();
	}

	private void OnApplicationQuit() {
		SaveGameData();
	}

	private void LoadGameData() {
		/*
		var path = GameDataJsonPath;
		if (File.Exists(path)) {
			var json = File.ReadAllText(path);
			JsonUtility.FromJsonOverwrite(json, gameDataSO);
		} 
		*/
	}

	private void SaveGameData() {
		/*
		var json = JsonUtility.ToJson(gameDataSO);
		File.WriteAllText(GameDataJsonPath, json);
		*/
	}
}