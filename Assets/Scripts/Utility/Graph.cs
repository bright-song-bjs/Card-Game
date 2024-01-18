using System.Collections.Generic;

public class Graph {
	private int[,] adjacencyMatrix;
	private int numberOfVertices;

	public Graph(int numberOfVertices) {
		adjacencyMatrix = new int[numberOfVertices, numberOfVertices];
		this.numberOfVertices = numberOfVertices;
	}

	public void AddEdge(int i, int j, int weight = 1) {
		adjacencyMatrix[i, j] = weight;
	}

	public List<int> AdjacentVerticesFrom(int i) {
		var edges = new List<int>();
		for (int j = 0; j < numberOfVertices; ++j) {
			if (adjacencyMatrix[i, j] != 0) {
				edges.Add(j);
			}
		}
		return edges;
	}

	public List<int> AdjacentVerticesTo(int j) {
		var edges = new List<int>();
		for (int i = 0; i < numberOfVertices; ++i) {
			if (adjacencyMatrix[i, j] != 0) {
				edges.Add(i);
			}
		}
		return edges;
	}

	public int WeightOfEdge(int i, int j) {
		return adjacencyMatrix[i, j];
	}
}