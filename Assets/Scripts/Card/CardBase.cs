using UnityEngine;
using UnityEngine.UI;

public class CardBase: MonoBehaviour {
  [SerializeField]
  private CardStyleSO cardStyleSO;

  [SerializeField]
  private Image cardBackImage;

  private void Awake() {
    cardBackImage.sprite = cardStyleSO.cardBackSprite;
  }
}
