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

	private void Start() {
		var player = PlayerController.Instance;
		var enemy = EnemyController.Instance;

		// initial player health points
		SetPlayerHealthPercentage(player.GetMaxHealthPoints());

		// initial enemy health points
		SetEnemyHealthPercentage(enemy.GetMaxHealthPoints());

		// initial player mana points
		SetPlayerManaPoints(player.GetInitialManaPoints());
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