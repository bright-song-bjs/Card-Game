using UnityEngine;

[CreateAssetMenu(
	fileName = "New Card Style SO", 
	menuName = "Scriptable Object/Card Style"
)]
public class CardStyleSO: ScriptableObject {
	public string cardName;

	public string cardDescription;
	
	public Sprite cardBackSprite;
}
