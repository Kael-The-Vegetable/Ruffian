using CardGames;
using UnityEngine;
using UnityEngine.Events;

public class CardSlot : MonoBehaviour, IHolder
{
	private CardDisplayer _cardDisplay;
	[field: SerializeField] public Suit[] AcceptedSuits { get; private set; }
	public UnityEvent CardRemoved { get; private set; } = new UnityEvent();
	public bool IsHolding => _cardDisplay != null;
	private void Awake()
	{
		_cardDisplay = GetComponentInChildren<CardDisplayer>();
		PointerManager.Instance.AddHolder(transform, this);
	}

	public void Link(CardDisplayer display)
	{
		_cardDisplay = display;
		_cardDisplay.transform.SetParent(transform);
		_cardDisplay.transform.localPosition = Vector3.zero;
	}

	public void Unlink()
	{
		_cardDisplay = null;
		CardRemoved.Invoke();
	}

	public bool AcceptsCard(CardDisplayer display)
	{
		bool found = false;
		for (int i = 0; i < AcceptedSuits.Length && !found; i++)
		{
			found = display.Card.Suit == AcceptedSuits[i];
		}
		return found;
	}
}
