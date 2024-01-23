using System.Collections.Generic;

public struct ICardCombination {
	public struct EditorItem {
		public ICardType[] components;
		public ACardType yield;
	}

	public Dictionary<ICardType, int> components;

	public ACardType yield;

	public int count;

	public ICardCombination(EditorItem item) {
		components = new Dictionary<ICardType, int>();
		foreach (var component in item.components) {
			if (components.ContainsKey(component)) {
				components[component] += 1;
			} else {
				components.Add(component, 1);
			}
		}
		yield = item.yield;
		count = item.components.Length;
	}
}