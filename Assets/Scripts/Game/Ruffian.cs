using UnityEngine;
using UnityEngine.UI;

public class Ruffian : MonoBehaviour
{
	[SerializeField] private DeckDisplayer _deck;
	[field: SerializeField] public CardSlot[] Room { get; private set; }
	[SerializeField] private Button _fleeButton;

	private void Start()
	{
		
	}
}
