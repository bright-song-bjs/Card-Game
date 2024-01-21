using UnityEngine;

public class HealCard: CardBase {
	public int healPoints;

	public override void Cast(Caster caster) {
		switch (caster) {
		case Caster.Player:
			HealPlayer();
			break;
		case Caster.Enemy:
			HealEnemy();
			break;
		}
	}

	public void HealPlayer() {
		var player = PlayerController.Instance;
		var healthPoints = player.GetHealthPoints();
		player.SetHealthPoints(healthPoints + healPoints);
	}

	public void HealEnemy() {
		var enemy = EnemyController.Instance;
		var healPoints = enemy.GetHealthPoints();
		enemy.SetHealthPoints(healPoints + healPoints);
	}
}