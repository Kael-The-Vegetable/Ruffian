using UnityEngine;

public interface IDraggable
{
	void PointerEnter();
	void PointerHold(bool isHolding);
	void PointerExit();
}
