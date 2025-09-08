using UnityEngine;

public class CardSlot : MonoBehaviour, IHolder
{
	private CardDisplayer _cardDisplay;
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

	public void Unlink() => _cardDisplay = null;
}
