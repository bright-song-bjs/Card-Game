using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GraphMenu: UIBase {
	public List<(int i,int j)> edges;

  public GraphVertex root;

  private Dictionary<int, GraphVertex> vertexByIndex;

  private Graph graph;

  private int[] indegree;

  private bool[] selected;

  private void Awake() {
    var vertices = FindObjectsOfType<GraphVertex>();
    var count = vertices.Length;
    graph = new Graph(count);
    
    foreach (var vertex in vertices) {
      vertexByIndex.Add(vertex.index, vertex);
    }

    foreach (var edge in edges) {
      graph.AddEdge(edge.i, edge.j);
    }

    // set up indegree array
    indegree = new int[count];
    for (int i = 0; i < count; ++i) {
      indegree[i] = graph.AdjacentVerticesTo(i).Count;
    }

    // set up selected array
    selected = new bool[count];
  }

  private void Start() {
    // var vertices = DataManager.Instance.GetPlayerHighlightedVertices();
    // simply initialize it here for test purposes
    var vertices = new List<int> { 0 };
    foreach (var vertex in vertices) {
      Select(vertex);
    }
  }

  private void UpdateGraph(out List<int> candidates) {
    candidates = new List<int>();
    for (int i = 0; i < indegree.Length; ++i) {
      if (selected[i]) {
        // update UI: highlighted

      } else {
        if (indegree[i] == 0) {
          candidates.Add(i);
          
          // update UI: candidate

        } else {
          // update UI: grayed-out

        }
      }
    }
  }

  private void Select(int i) {
    selected[i] = true;
    foreach (var vertex in graph.AdjacentVerticesFrom(i)) {
      indegree[vertex] -= 1;
    }
  }
}