using CardGames;
using System;
using UnityEngine;

public class DeckDisplayer : MonoBehaviour
{
	public RuffianDeck RuffianDeck { get; private set; } = RuffianDeck.RuffianStandard();
	[SerializeField] private GameObject _cardDisplay;
	[SerializeField] private CardDisplayer _cardPrefab;
	private void Awake()
	{
		RuffianDeck.Shuffle();
		_cardDisplay.SetActive(RuffianDeck.Cards.Length > 0);
	}

	public CardDisplayer DealCard()
	{
		var display = Instantiate(_cardPrefab);
		display.Card = RuffianDeck.Deal(1)[0];
		return display;
	}
	public CardDisplayer[] DealCards(int numOfCards)
	{
		Card[] cards = RuffianDeck.Deal(numOfCards);
		numOfCards = cards.Length;
		CardDisplayer[] displayers = new CardDisplayer[numOfCards];
		
		for (int i = 0; i < numOfCards; i++)
		{
			displayers[i] = Instantiate(_cardPrefab);
			displayers[i].Card = cards[i];
		}

		return displayers;
	}
}
