using CardGames;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSpriteLibrary", menuName = "Card Games/Card Sprite Library")]
public class CardSpriteLibrary : ScriptableObject
{
	[field: SerializeField] public Sprite Hidden { get; private set; }
	[field: SerializeField] public Sprite Empty { get; private set; }
	[field: SerializeField] public Sprite[] Deck { get; private set; }

	public Sprite GetSprite(Card card)
	{
		string text = card.Suit.ToString().Substring(0, 1).ToLower() + ((int)card.Rank).ToString();
		return GetSprite(text);
	}
	public Sprite GetSprite(string text)
	{
		Sprite sprite = null;
		for (int i = 0; i < Deck.Length && sprite == null; i++)
		{
			if (Deck[i].name == text)
			{
				sprite = Deck[i];
			}
		}
		return sprite;
	}
}
