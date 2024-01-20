using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
	fileName = "New Game Data SO", 
	menuName = "Scriptable Object/Game Data"
)]
public class GameDataSO: ScriptableObject {
	// initialize it here for test purposes
	public Dictionary<CardType, int> playerCardCollection = 
	  new Dictionary<CardType, int> {
			{ CardType.HealCard, 1 },
			{ CardType.AttackCard, 1 },
			{ CardType.SpawnCard, 1 },
		};

	public List<int> playerUnlockedVertices =
	  new List<int>();
}