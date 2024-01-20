using System.Collections.Generic;
using UnityEngine;

public class GraphLibrary: MonoBehaviour {
	public static GraphLibrary Instance { get; private set; }

	[SerializeField]
	private List<Node> nodes;

	[SerializeField]
	private List<NodeConnection> connections;

	[SerializeField]
	private Arrow arrow;
	
	private Dictionary<int, Node> nodeByVertex =
		new Dictionary<int, Node>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var node in nodes) {
			nodeByVertex.Add(node.index, node);
		}
	}

	public int NumberOfVertices {
		get => nodes.Count;
	}

	public Node GetNodeByVertex(int vertex) {
		return nodeByVertex[vertex];
	}

	public Arrow GetArrow() {
		return arrow;
	}

	public List<(int i, int j)> GetEdges() {
		var edges = new List<(int i, int j)>();
		foreach (var connection in connections) {
			edges.Add((connection.from, connection.to));
		}
		return edges;
	}
}