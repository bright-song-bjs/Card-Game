using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphView: UIBase {
  public RectTransform nodesLayer;

  public RectTransform arrowsLayer;
  
  private Dictionary<int, Node> nodeByVertex;
  
  private void Start() {
    var library = GraphLibrary.Instance;

    // instantiate node prefabs with correct locations
    var placeholders = FindObjectsOfType<NodePlaceholder>();
    foreach (var placeholder in placeholders) {
      // instantiate
      var nodePrefab = library.GetNodeByVertex(placeholder.vertex);
      var node = Instantiate(nodePrefab, nodesLayer);

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
  }

  private void Update() {
    var states = GraphManager.Instance.GetNodeStates();
    for (int i = 0; i < states.Length; ++i) {
      var node = nodeByVertex[i];
      node.SetState(states[i]);
    }
  }

  // test-only buttons
  public void OnButtonClick_StartInteracting() {
    var mask = GraphManager.Instance.mask;
    for (int i = 0; i < mask.Length; ++i) {
      mask[i] = false;
    }
  }

  public void OnButtonClick_EndInteracting() {
    var mask = GraphManager.Instance.mask;
    for (int i = 0; i < mask.Length; ++i) {
      mask[i] = true;
    }
  }

  public void OnButtonClick_GoBack() {
    UIManager.Instance.CloseCurrentPanel();
  }
}