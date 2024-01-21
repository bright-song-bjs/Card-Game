using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHUD: UIBase {
	[SerializeField]
	private HealthBar playerHealthBar;

	[SerializeField]
	private HealthBar enemyHealthBar;

	[SerializeField]
	private TextMeshProUGUI playerManaPointsTMP;

	private void OnEnable() {
		var player = PlayerController.Instance;
		if (player != null) {
			player.OnHealthPercentageChange += SetPlayerHealthPercentage;
			player.OnManaPointsChange += SetPlayerManaPoints;
		}
		var enemy = EnemyController.Instance;
		if (enemy != null) {
			enemy.OnHealthPercentageChange += SetEnemyHealthPercentage;
		}
	}

	private void OnDisable() {
		var player = PlayerController.Instance;
		if (player != null) {
			player.OnHealthPercentageChange -= SetPlayerHealthPercentage;
			player.OnManaPointsChange -= SetPlayerManaPoints;
		}
		var enemy = EnemyController.Instance;
		if (enemy != null) {
			enemy.OnHealthPercentageChange -= SetEnemyHealthPercentage;
		}
	}

	public void SetPlayerHealthPercentage(float percentage) {
		playerHealthBar.SetHealthPercentage(percentage);
	}

	public void SetEnemyHealthPercentage(float percentage) {
		enemyHealthBar.SetHealthPercentage(percentage);
	}

	public void SetPlayerManaPoints(int manaPoints) {
		playerManaPointsTMP.text = manaPoints.ToString();
	}

	// test-only buttons
	public void OnButtonClick_Pause() {

	}

	public void OnButtonClick_Leave() {
		SceneManager.LoadScene("MainScene");
		UIManager.Instance.CloseCurrentPanel();
	}

	public void OnButtonClick_GraphView() {
		UIManager.Instance.OpenPanel(UIType.GraphView);
	}
}