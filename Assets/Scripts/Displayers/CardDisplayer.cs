using CardGames;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayer : MonoBehaviour, IDraggable
{
	private Image _img;
	private IHolder _holder;

	[SerializeField] private Card _card;
	[SerializeField] private bool _hidden;


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
		_img = GetComponent<Image>();
		_holder = GetComponentInParent<IHolder>();
		CheckSprite();
		PointerManager.Instance.AddDraggable(transform, this);
	}

	private void CheckSprite()
	{
		if (_hidden)
		{ // not visible
			_img.sprite = CardManager.Instance.SpriteLibrary.Hidden;
		}
		else if (_card == null)
		{ // empty
			_img.sprite = CardManager.Instance.SpriteLibrary.Empty;
		}
		else
		{
			_img.sprite = CardManager.Instance.SpriteLibrary.GetSprite(_card);
		}
	}

	#region Movements
	public void PointerEnter()
	{
		
	}
	public void PointerHold(bool isHolding)
	{
		if (isHolding)
		{
			InputManager.Instance.Pointer.AddListener(PointerMoved);
		}
		else
		{
			InputManager.Instance.Pointer.RemoveListener(PointerMoved);
			IHolder newHolder = PointerManager.Instance.CheckForHolder(transform.position);
			Debug.Log(newHolder);
			if (newHolder != null)
			{
				if (_holder != null) _holder.Unlink();

				_holder = newHolder;
				_holder.Link(this);
			}
			else
			{
				transform.localPosition = Vector3.zero;
			}
		}
	}
	public void PointerExit()
	{
		
	}

	private void PointerMoved(Vector2 newPos)
	{
		transform.position = Camera.main.ScreenToWorldPoint(newPos).Flatten();
	}
	#endregion
}
