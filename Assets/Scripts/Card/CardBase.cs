using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class CardBase: MonoBehaviour, IPointerClickHandler {
  [HideInInspector]
  public Caster owner;

  [SerializeField]
  private CardStyleSO cardStyleSO;

  [SerializeField]
  private Image cardBackImage;

  [SerializeField]
  private TextMeshProUGUI cardNameTMP;

  [SerializeField]
  private TextMeshProUGUI cardDescriptionTMP;

  private void Awake() {
    cardBackImage.sprite = cardStyleSO.cardBackSprite;
    cardNameTMP.text = cardStyleSO.cardName;
    cardDescriptionTMP.text = cardStyleSO.cardDescription;
  }

  public abstract void Cast(Caster caster);

  public void OnPointerClick(PointerEventData eventData) {
    if (owner == Caster.Player) {
      Cast(owner);
      // here it simply disappears for test purposes
      Destroy(gameObject);
    }
  }
}
