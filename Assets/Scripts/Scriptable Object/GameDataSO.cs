using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
	fileName = "New Game Data SO", 
	menuName = "Scriptable Object/Game Data"
)]
public class GameDataSO: ScriptableObject {
	public LevelID currentLevelID = LevelID.Level_0;

	public Dictionary<ECardType, int> eCardsCollection = 
		new Dictionary<ECardType, int> {
			
		};
}