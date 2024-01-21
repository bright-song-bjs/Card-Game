using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphView: UIBase {
  [SerializeField]
  private RectTransform nodesLayer;

  [SerializeField]
  private RectTransform arrowsLayer;

  [SerializeField]
  private RectTransform battleSceneOnly;

  [SerializeField]
  private TextMeshProUGUI playerManaPointsTMP;
  
  [SerializeField]
  private TextMeshProUGUI choosingButtonTMP;
  
  private Dictionary<int, Node> nodeByVertex =
    new Dictionary<int, Node>();

  private bool playerCanChoose = false;
  
  private void OnEnable() {
    var player = PlayerController.Instance;
    if (player != null) {
      // open Graph View in Battle Scene
      battleSceneOnly.gameObject.SetActive(true);
      SetPlayerManaPoints(player.GetManaPoints());
      player.OnManaPointsChange += SetPlayerManaPoints;
    } else {
      // open Graph View in Main Scene
      battleSceneOnly.gameObject.SetActive(false);
    }
  }

  private void OnDisable() {
    var player = PlayerController.Instance;
    if (player != null) {
      // open Graph View in Battle Scene
      player.OnManaPointsChange -= SetPlayerManaPoints;
    } else {
      // open Graph View in Main Scene
    }
  }
  
  private void Start() {
    var library = GraphLibrary.Instance;

    // instantiate node prefabs with correct locations
    var placeholders = FindObjectsOfType<NodePlaceholder>();
    foreach (var placeholder in placeholders) {
      // instantiate
      var nodePrefab = library.GetNodeByVertex(placeholder.vertex);
      var node = Instantiate(nodePrefab, nodesLayer);
      nodeByVertex.Add(placeholder.vertex, node);

      // adjust location
      var target = placeholder.GetComponent<RectTransform>();
      var curr = node.GetComponent<RectTransform>();
      curr.anchoredPosition = target.anchoredPosition;
      curr.localEulerAngles = target.localEulerAngles;

      // destroy the placeholder
      Destroy(placeholder.gameObject);
    }

    // instantiate arrows at correct locations
    foreach (var edge in library.GetEdges()) {
      var arrow = Instantiate(library.GetArrow(), arrowsLayer);
      var i = nodeByVertex[edge.i].GetComponent<RectTransform>();
      var j = nodeByVertex[edge.j].GetComponent<RectTransform>();
      // 85 is temporarily hardcoded here which depends on node size
      arrow.PlaceAt(i.anchoredPosition, j.anchoredPosition, 85f);
    }

    // player can not unlock any node at this stage
    StopInteracting();
  }

  private void Update() {
    var states = GraphManager.Instance.GetNodeStatesOfAll();
    for (int i = 0; i < states.Length; ++i) {
      var node = nodeByVertex[i];
      node.SetState(states[i]);
    }
  }

  public void SetPlayerManaPoints(int manaPoints) {
		playerManaPointsTMP.text = manaPoints.ToString();
	}

  // test-only buttons
  public void OnButtonClick_Interacting() {
    if (playerCanChoose) {
      StopInteracting();
    } else {
      StartInteracting();
    }
  }

  public void OnButtonClick_GoBack() {
    UIManager.Instance.CloseCurrentPanel();
  }

  private void StartInteracting() {
    choosingButtonTMP.text = "Stop Choosing";
    playerCanChoose = true;
    GraphManager.Instance.UnmaskAll();
  }

  private void StopInteracting() {
    choosingButtonTMP.text = "Start Choosing";
    playerCanChoose = false;
    GraphManager.Instance.MaskAll();
  }
}