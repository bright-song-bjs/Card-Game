using System.Collections.Generic;
using UnityEngine;

public class GraphLibrary: MonoBehaviour {
	public static GraphLibrary Instance { get; private set; }

	[SerializeField]
	private List<Node> nodes;

	[SerializeField]
	private List<(int from, int to)> connections;

	[SerializeField]
	private Arrow arrow;
	
	private Dictionary<int, Node> nodeByVertex;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var node in nodes) {
			nodeByVertex[node.index] = node;
		}
	}

	public int NumberOfVertices {
		get => nodes.Count;
	}

	public Node GetNodeByVertex(int vertex) {
		return nodeByVertex[vertex];
	}

	public List<(int i, int j)> GetEdges() {
		return connections;
	}

	public Arrow GetArrow() {
		return arrow;
	}
}