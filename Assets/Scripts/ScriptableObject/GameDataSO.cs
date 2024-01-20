using System.Collections.Generic;
using UnityEngine;

public class GameDataSO: ScriptableObject {
	public Dictionary<CardType, int> playerCardCollection =
		new Dictionary<CardType, int>();

	public List<int> playerUnlockedVertices =
	  new List<int>();
}