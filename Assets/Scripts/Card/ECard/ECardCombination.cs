using System.Collections.Generic;

public struct ECardCombination {
	public struct EditorItem {
		public ECardType[] components;
		public ICardType yield;
	}

	public Dictionary<ECardType, int> components;

	public ICardType yield;

	public int count;

	public ECardCombination(EditorItem item) {
		components = new Dictionary<ECardType, int>();
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