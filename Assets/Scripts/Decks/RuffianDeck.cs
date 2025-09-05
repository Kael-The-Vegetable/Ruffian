using CardGames;
using System;
public class RuffianDeck : Deck
{
	public RuffianDeck(Card[] cards)
	{
		Cards = cards;
	}
	public static RuffianDeck RuffianStandard()
	{
		Card[] cards = new Card[STANDARD_DECK_SIZE - 8]; // removing values above 10 from red suits

		for (int i = 0; i < 4; i++) // 4 suits
		{
			int suitLen = i < 3 ? 13 : 9; // 13 for black suits 9 for reds
			for (int j = 0; j < suitLen; j++)
			{
				cards[i * 13 - (i > 2 ? 4 : 0) + j] = new Card((Suit)i, (Rank)(j + 2));
			}
		}

		return new RuffianDeck(cards);
	}
}
