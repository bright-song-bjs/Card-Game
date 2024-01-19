using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GraphManager: MonoBehaviour {
  public static GraphManager Instance { get; private set; }

	public Graph graph;
  
  public int[] indegree;

  public bool[] unlocked;

  public bool[] mask;

  private void Awake() {
    if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

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
  }

  private void Start() {
    // var vertices = DataManager.Instance.GetPlayerUnlockedVertices();
    // simply initialize it here for test purposes
    var vertices = new List<int> { 0 };
    foreach (var vertex in vertices) {
      UnlockVertex(vertex);
    }
  }

  public void UnlockVertex(int vertex) {
    unlocked[vertex] = true;
    DataManager.Instance.AddPlayerUnlockedVertex(vertex);
    foreach (var j in graph.AdjacentVerticesFrom(vertex)) {
      indegree[j] -= 1;
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

  public NodeState[] GetNodeStates() {
    var states = new NodeState[indegree.Length];
    for (int i = 0; i < indegree.Length; ++i) {
      states[i] = GetNodeStateOfVertex(i);
    }
    return states;
  }
}