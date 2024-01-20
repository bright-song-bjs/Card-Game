using System.Collections.Generic;
using UnityEngine;

public class GraphManager: MonoBehaviour {
  public static GraphManager Instance { get; private set; }

  private Graph graph;
  
  private int[] indegree;

  private bool[] unlocked;

  private bool[] mask;

  private void Awake() {
    if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
  }

  private void Start() {
    SetUpGraph();
  }

  public void UnlockVertex(int vertex) {
    unlocked[vertex] = true;
    DataManager.Instance.AddPlayerUnlockedVertex(vertex);
    foreach (var j in graph.AdjacentVerticesFrom(vertex)) {
      indegree[j] -= 1;
    }
  }

  public void MaskVertex(int vertex) {
    mask[vertex] = true;
  }

  public void MaskAll() {
    for (int i = 0; i < mask.Length; ++i) {
      mask[i] = true;
    }
  }

  public void UnmaskAll() {
    for (int i = 0; i < mask.Length; ++i) {
      mask[i] = false;
    }
  }

  public NodeState GetNodeStateOfVertex(int vertex) {
    if (unlocked[vertex]) {
      return NodeState.Unlocked;
    } else {
      if (indegree[vertex] == 0 && !mask[vertex]) {
        return NodeState.Candidate;
      } else {
        return NodeState.Locked;
      }
    }
  }

  public NodeState[] GetNodeStatesOfAll() {
    var states = new NodeState[indegree.Length];
    for (int i = 0; i < indegree.Length; ++i) {
      states[i] = GetNodeStateOfVertex(i);
    }
    return states;
  }

  private void SetUpGraph() {
    // set up graph
    var numberOfVertices = GraphLibrary.Instance.NumberOfVertices;
    graph = new Graph(numberOfVertices);

    foreach (var edge in GraphLibrary.Instance.GetEdges()) {
      graph.AddEdge(edge.i, edge.j);
    }

    // set up indegree array
    indegree = new int[numberOfVertices];
    for (int i = 0; i < numberOfVertices; ++i) {
      indegree[i] = graph.AdjacentVerticesTo(i).Count;
    }

    // set up unlocked array
    unlocked = new bool[numberOfVertices];

    // set up mask array
    mask = new bool[numberOfVertices];

    // update graph from saved date
    var vertices = DataManager.Instance.GetPlayerUnlockedVertices();
    // modify it here for test purposes
    vertices = new List<int>();
    foreach (var vertex in vertices) {
      UnlockVertex(vertex);
    }
  }
}