using BasicUtilities;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : Singleton<PointerManager>
{
	private Camera _cam;
	private Dictionary<Transform, IDraggable> _knownDraggableComponents = new Dictionary<Transform, IDraggable>();
	private IDraggable _draggable;
	private bool _isDragging = false;
	protected override void Initialize()
	{
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
	private void PointerMove(Vector2 pos)
	{
		if (_isDragging) return;

		Ray pointRay = _cam.ScreenPointToRay(pos);
		RaycastHit2D[] hits = Physics2D.RaycastAll(pointRay.origin, pointRay.direction);
		
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
	}
}
