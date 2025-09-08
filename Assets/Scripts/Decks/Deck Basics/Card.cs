using System;
using UnityEngine;

namespace CardGames
{
	[Serializable]
	public class Card
	{
		[SerializeField] private Suit _suit;
		public Suit Suit => _suit;
		[SerializeField] private Rank _rank;
		public Rank Rank => _rank;

		public Card() { }
		public Card(Suit suit, Rank rank)
		{
			_suit = suit;
			_rank = rank;
		}

		public override string ToString()
		{
			return Suit + " " + Rank;
		}

		public static bool operator ==(Card lhs, Card rhs)
		{
			return lhs?.Suit == rhs?.Suit && lhs?.Rank == rhs?.Rank;
		}
		public static bool operator !=(Card lhs, Card rhs)
		{
			return lhs?.Suit != rhs?.Suit || lhs?.Rank != rhs?.Rank;
		}
	}
}

