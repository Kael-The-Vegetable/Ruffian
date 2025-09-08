using UnityEngine;

public interface IDraggable
{
	void PointerEnter();
	void PointerHold(bool isHolding);
	void PointerExit();
}

public interface IHolder
{
	public bool IsHolding { get; }
	void Unlink();
	void Link(CardDisplayer display);
}
