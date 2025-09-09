using CardGames;
using UnityEngine;

public interface IDraggable
{
	void PointerEnter();
	void PointerHold(bool isHolding);
	void PointerExit();
}

public interface IHolder
{
	Suit[] AcceptedSuits { get; }
	bool IsHolding { get; }
	bool AcceptsCard(CardDisplayer displayer);
	void Unlink();
	void Link(CardDisplayer display);
}
