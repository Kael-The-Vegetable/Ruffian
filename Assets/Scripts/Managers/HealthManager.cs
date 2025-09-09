using BasicUtilities;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : Singleton<HealthManager>
{
	[SerializeField] private NumberSpriteLibrary _spriteLibrary;
	[SerializeField] private Image _img;
	[SerializeField, Range(0, 20)] private int _health = 20;
	private int _displayedHealth;

	private Coroutine _healthCoroutine;
	public int Health
	{
		get => _health;

		set
		{
			if (_health == value) return;
			_health = value;
			if (_healthCoroutine != null) StopCoroutine(_healthCoroutine);
			_healthCoroutine = StartCoroutine(HealthTick());
		}
	}
	protected override void Initialize()
	{
		_displayedHealth = _health;
		if (_img == null) _img = GetComponentInChildren<Image>();
	}

	private IEnumerator HealthTick()
	{
		while (_displayedHealth != _health)
		{
			_displayedHealth += Math.Sign(_health - _displayedHealth);
			_img.sprite = _spriteLibrary.GetSprite(_displayedHealth);
			yield return null;
		}
	}
}
