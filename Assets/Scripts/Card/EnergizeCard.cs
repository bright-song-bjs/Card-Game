using UnityEngine;

public class EnergizeCard: CardBase {
	public int energizePoints;

	public override void Cast(Caster caster) {
		EnergizePlayer();
	}

	private void EnergizePlayer() {
		var player = PlayerController.Instance;
		if (player != null) {
			var manaPoints = player.GetManaPoints();
			player.SetManaPoints(manaPoints + energizePoints);
		}
	}
}