using CardGames;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CardDisplayer : MonoBehaviour, IDraggable
{
	private SpriteRenderer _renderer;
	[SerializeField] private Card _card;
	[SerializeField] private bool _hidden;

	private bool _followingMouse = false;

	public Card Card
	{
		get => _card;
		set
		{
			if (value != _card)
			{
				_card = value;
				CheckSprite();
			}
		}
	}

	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		CheckSprite();
		PointerManager.Instance.AddDraggable(transform, this);
	}

	private void CheckSprite()
	{
		if (_hidden)
		{ // not visible
			_renderer.sprite = CardManager.Instance.SpriteLibrary.Hidden;
		}
		else if (_card == null)
		{ // empty
			_renderer.sprite = CardManager.Instance.SpriteLibrary.Empty;
		}
		else
		{
			_renderer.sprite = CardManager.Instance.SpriteLibrary.GetSprite(_card);
		}
	}

	#region Movements
	public void PointerEnter()
	{
		Debug.Log("POINT ENTERED");
	}
	public void PointerHold(bool isHolding)
	{
		throw new System.NotImplementedException();
	}
	public void PointerExit()
	{
		Debug.Log("POINT EXITED");
	}
	#endregion
}
