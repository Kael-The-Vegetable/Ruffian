using BasicUtilities;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
	[field: SerializeField] public CardSpriteLibrary SpriteLibrary { get; private set; }
	protected override void Initialize()
	{
		
	}
}
