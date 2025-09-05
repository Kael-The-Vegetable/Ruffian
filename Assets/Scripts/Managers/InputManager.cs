using BasicUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : PersistentSingleton<InputManager>
{
	[field: SerializeField] public PlayerInput Input { get; private set; }
	protected override void Initialize()
	{
		
	}
}
