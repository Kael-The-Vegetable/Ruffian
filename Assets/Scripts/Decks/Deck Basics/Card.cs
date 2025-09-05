using UnityEngine;

namespace CardGames
{
	public class Card
	{
		public Suit Suit { get; protected set; }
		public Rank Rank { get; protected set; }

		public Card() { }
		public Card(Suit suit, Rank rank)
		{
			Suit = suit;
			Rank = rank;
		}

		public override string ToString()
		{
			return Suit + " " + Rank;
		}
	}
}

