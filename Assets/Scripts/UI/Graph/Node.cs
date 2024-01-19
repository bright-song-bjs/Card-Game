using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Node: MonoBehaviour {
	public int index;
	
	public Sprite lockedStateSprite;

	public Sprite candidateStateSprite;

	public Sprite unlockedStateSprite;

	private NodeState currentState = NodeState.None;

	private Image image;

	private Button button;

	private void Awake() {
		image = GetComponent<Image>();
		button = gameObject.AddComponent<Button>();
		button.transition = Selectable.Transition.None; 
		button.onClick.AddListener(OnButtonClick);
	}

	public void SetState(NodeState state) {
		if (currentState != state) {
			currentState = state;
			switch (state) {
			case NodeState.None:
				image.sprite = null;
				break;
			case NodeState.Locked:
				image.sprite = lockedStateSprite;
				break;
			case NodeState.Candidate:
				image.sprite = candidateStateSprite;
				break;
			case NodeState.Unlocked:
				image.sprite = unlockedStateSprite;
				break;
			}
			// adjust the size: native or whatever
			image.SetNativeSize();
		}
	}

	private void OnButtonClick() {
		switch (currentState) {
		case NodeState.None:
			break;
		case NodeState.Locked:
			// maybe show some information
			break;
		case NodeState.Candidate:
			// the player will be able to choose then unlock
			GraphManager.Instance.UnlockVertex(index);
			break;
		case NodeState.Unlocked:
			// maybe show some information
			break;
		default:
			break;
		}
	}
}