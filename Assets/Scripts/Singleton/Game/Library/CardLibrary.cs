using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CardLibrary: MonoBehaviour {
	public static CardLibrary Instance { get; private set; }

	[SerializeField]
	private List<CardLibraryItem> items;

	private Dictionary<CardType, CardBase> cardBaseByCardType;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		foreach (var item in items) {
			cardBaseByCardType[item.cardType] = item.cardBase;
		}
	}

	public CardBase Get(CardType cardType) {
		return cardBaseByCardType[cardType];
	}
}