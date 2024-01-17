using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(
	fileName = "New Card Style SO", 
	menuName = "Scriptable Object/Card/Style"
)]
public class CardStyleSO: ScriptableObject {
	public Sprite cardBackSprite;
}
