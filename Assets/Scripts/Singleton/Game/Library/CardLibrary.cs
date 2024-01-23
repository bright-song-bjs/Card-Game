using System.Collections.Generic;
using UnityEngine;

public class CardLibrary: MonoBehaviour {
	public static CardLibrary Instance { get; private set; }

	[SerializeField]
	private List<ECard> eCardPrefabs;

	[SerializeField]
	private List<ICard> iCardPrefabs;

	[SerializeField]
	private List<ACard> aCardPrefabs;

	private Dictionary<ECardType, ECard> eCardPrefabByType =
		new Dictionary<ECardType, ECard>();

	private Dictionary<ICard, ICard> iCardPrefabByType =
		new Dictionary<ICard, ICard>();

	private Dictionary<ACard, ACard> aCardPrefabByType =
		new Dictionary<ACard, ACard>();

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var prefab in eCardPrefabs) {
			eCardPrefabByType.Add(prefab.type, prefab);
		}

		foreach (var prefab in iCardPrefabs) {
			iCardPrefabByType.Add(prefab.type, prefab);
		}

		foreach (var prefab in aCardPrefabs) {
			aCardPrefabByType.Add(prefab.type, prefab);
		}
	}

	public ECard GetECardPrefab(ECardType type) {
		return eCardPrefabByType[type];
	}

	public ICard GetICardPrefab(ICard type) {
		return iCardPrefabByType[type];
	} 

	public ACard GetACardPrefab(ACard type) {
		return aCardPrefabByType[type];
	}

	public void CheckCombinationMatch() {

	}
}