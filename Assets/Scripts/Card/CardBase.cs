using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBase: MonoBehaviour {
  [SerializeField]
  private CardStyleSO cardStyleSO;

  [SerializeField]
  private Image cardBackImage;

  [SerializeField]
  private TextMeshProUGUI cardName;

  [SerializeField]
  private TextMeshProUGUI cardDescription;

  private void Awake() {
    cardBackImage.sprite = cardStyleSO.cardBackSprite;
    cardName.text = cardStyleSO.cardName;
    cardDescription.text = cardStyleSO.cardDescription;
  }
}
