using UnityEngine;

public class AttackCard: CardBase {
	public int attackPoints;

  public override void Cast(Caster caster) {
		switch (caster) {
		case Caster.Player:
			AttackEnemy();
			break;
		case Caster.Enemy:
			AttackPlayer();
			break;
		}
	}

	private void AttackEnemy() {
		var enemy = EnemyController.Instance;
		if (enemy != null) {
			var healPoints = enemy.GetHealthPoints();
			enemy.SetHealthPoints(healPoints - attackPoints);
		}
	}

	private void AttackPlayer() {
		var player = PlayerController.Instance;
		if (player != null) {
			var healthPoints = player.GetHealthPoints();
			player.SetHealthPoints(healthPoints - attackPoints);
		}
	}
}