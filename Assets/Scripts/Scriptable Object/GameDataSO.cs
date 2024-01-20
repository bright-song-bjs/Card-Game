using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
	fileName = "New Game Data SO", 
	menuName = "Scriptable Object/Game Data"
)]
public class GameDataSO: ScriptableObject {
	public Dictionary<CardType, int> playerCardCollection =
		new Dictionary<CardType, int>();

	public List<int> playerUnlockedVertices =
	  new List<int>();
}