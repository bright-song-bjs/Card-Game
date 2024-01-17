public class BattleStateMachine {
	private BattleState currentState = BattleState.none;

	public void Enter(BattleState state) {
		ExitCurrentState();
		currentState = state;
		EnterNewState();
	}

	private void ExitCurrentState() {
		switch (currentState) {
		case BattleState.playerTurn:
			break;
		case BattleState.enemyTurn:
			break;
		default:
			break;
		}
	}

	private void EnterNewState() {
		switch (currentState) {
		case BattleState.playerTurn:
			break;
		case BattleState.enemyTurn:
			break;
		default:
			break;
		}
	}
}