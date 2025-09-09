using UnityEngine;

public class DeckDisplayer : MonoBehaviour
{
	public RuffianDeck RuffianDeck { get; private set; } = RuffianDeck.RuffianStandard();

	private void Awake()
	{
		RuffianDeck.Shuffle();
	}
}
