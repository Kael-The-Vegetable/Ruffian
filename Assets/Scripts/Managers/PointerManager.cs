using BasicUtilities;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : Singleton<PointerManager>
{
	#region Layer Names
	public const string CARD_LAYER = "Card";
	public const string HOLDER_LAYER = "Holder";

	private int _cardLayer;
	private int _holdLayer;
	#endregion

	private Camera _cam;
	
	private Dictionary<Transform, IDraggable> _knownDraggableComponents = new Dictionary<Transform, IDraggable>();
	private IDraggable _draggable;
	private bool _isDragging = false;

	private Dictionary<Transform, IHolder> _knownHoldingComponents = new Dictionary<Transform, IHolder>();
	protected override void Initialize()
	{
		_cardLayer = LayerMask.GetMask(CARD_LAYER);
		_holdLayer = LayerMask.GetMask(HOLDER_LAYER);

		_cam = Camera.main;
		InputManager.Instance.Pointer.AddListener(PointerMove);
		InputManager.Instance.LeftClick.AddListener(LeftClicked);
	}

	private void OnDestroy()
	{
		if (InputManager.HasInstance)
		{
			InputManager.Instance.Pointer.RemoveListener(PointerMove);
			InputManager.Instance.LeftClick.RemoveListener(LeftClicked);
		}
	}

	#region Dictionaries
	public void AddDraggable(Transform obj, IDraggable draggable)
	{
		if (!_knownDraggableComponents.ContainsKey(obj))
		{
			_knownDraggableComponents.Add(obj, draggable);
		}
		else
		{
			_knownDraggableComponents[obj] = draggable;
		}
	}
	public void RemoveDraggable(Transform obj)
	{
		if (_knownDraggableComponents.ContainsKey(obj)) _knownDraggableComponents.Remove(obj);
	}
	public void AddHolder(Transform obj, IHolder holder)
	{
		if (!_knownHoldingComponents.ContainsKey(obj))
		{
			_knownHoldingComponents.Add(obj, holder);
		}
		else
		{
			_knownHoldingComponents[obj] = holder;
		}
	}
	public void RemoveHolder(Transform obj)
	{
		if (_knownHoldingComponents.ContainsKey(obj)) _knownHoldingComponents.Remove(obj);
	}
	#endregion

	private void PointerMove(Vector2 pos)
	{
		if (_isDragging || _cam == null) return;

		Ray pointRay = _cam.ScreenPointToRay(pos);
		RaycastHit2D[] hits = Physics2D.RaycastAll(pointRay.origin, pointRay.direction, 100, _cardLayer);
		
		IDraggable dragPoint = null;
		for (int i = 0; i < hits.Length && dragPoint == null; i++)
		{
			_knownDraggableComponents.TryGetValue(hits[i].transform, out dragPoint);
		}

		if (dragPoint != _draggable)
		{
			_draggable?.PointerExit();
			_draggable = dragPoint;
			_draggable?.PointerEnter();
		}
	}
	private void LeftClicked(bool active)
	{
		_isDragging = active;
		if (_draggable == null) return;
		_draggable.PointerHold(active);
	}

	public IHolder CheckForHolder(Vector2 pos)
	{
		Vector3 camFocusedPos = new Vector3(pos.x, pos.y, _cam.transform.position.z);
		RaycastHit2D[] hits = Physics2D.RaycastAll(camFocusedPos, _cam.transform.forward, 100, _holdLayer);

		IHolder holder = null;
		for (int i = 0; i < hits.Length && holder == null; i++)
		{
			_knownHoldingComponents.TryGetValue(hits[i].transform, out holder);
		}

		return holder;
	}
}
