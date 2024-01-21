using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour {
	[SerializeField]
	private Image currentHealthLayer;

	[SerializeField]
	private Image transitionLayer;

	[SerializeField]
	private float transitionPerSecond;

	private float targetFill;

	private float currentFill;

	private void Update() {
		if (!Mathf.Approximately(currentFill, targetFill)) {
			currentFill = Mathf.MoveTowards(
				currentFill, 
				targetFill,
				transitionPerSecond * Time.deltaTime
			);
			transitionLayer.fillAmount = currentFill;
		}
	}

	public void SetHealthPercentage(float percentage) {
		currentHealthLayer.fillAmount = percentage;
		targetFill = percentage;
	}
}