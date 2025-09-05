using System;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CardGames
{
	public class Deck
	{
		public const byte STANDARD_DECK_SIZE = 52;
		public Card[] Cards { get; protected set; }

		public Deck()
		{
			Cards = new Card[0];
		}
		public Deck(Card[] cards)
		{
			Cards = cards;
		}
		
		public void Shuffle()
		{
			int j;
			for (int i = Cards.Length - 1; i > 0; i--)
			{
				j = Random.Range(0, i + 1);
				(Cards[i], Cards[j]) = (Cards[j], Cards[i]);
			}
		}

		public Card[] Deal(int numToDeal)
		{
			if (numToDeal > Cards.Length) numToDeal = Cards.Length;

			Card[] dealtCards = new Card[numToDeal];
			for (int i = 0; i < numToDeal; i++)
			{
				dealtCards[i] = Cards[^(i + 1)];
			}
			Cards = Cards.GetRange(0, Cards.Length - numToDeal);
			return dealtCards;
		}

		public void AddCards(Card[] cards) => Cards = Cards.AddRange(cards);

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Cards.Length; i++)
			{
				sb.Append(Cards[i].ToString());
				sb.Append(", ");
			}
			return sb.ToString();
		}

		public static Deck Standard()
		{
			int suitLen = Enum.GetNames(typeof(Suit)).Length;
			int rankLen = Enum.GetNames(typeof(Rank)).Length;
			Card[] cards = new Card[suitLen * rankLen];
			for (int i = 0; i < suitLen; i++)
			{
				for (int j = 0; j < rankLen; j++)
				{
					cards[i * rankLen + j] = new Card((Suit)i, (Rank)(j + 2)); // rank starts at 2
				}
			}
			return new Deck(cards);
		}
	}
}

