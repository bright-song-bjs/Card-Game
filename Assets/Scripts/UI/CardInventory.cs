using UnityEngine;
using UnityEngine.UI;

public class CardInventory: UIBase {
	[SerializeField]
	private RectTransform content;

	private void Start() {
		var collection = GameManager.Instance.GetECardCollection();
		foreach ((var eCardType, var count) in collection) {
			for (int i = 0; i < count; ++i) {
				var eCardPrefab = CardLibrary.Instance.GetECardPrefab(eCardType);
				Instantiate(eCardPrefab, content, false);
			}
		}
	}
}