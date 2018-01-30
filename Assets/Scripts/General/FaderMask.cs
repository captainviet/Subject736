using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderMask : MonoBehaviour {

	public float fadeOffset;
	public float gapDuration;
	private Action _callback;
	private SpriteRenderer _sr;
	private bool _useWhite;

	public void FadeEffect(Action callback = null)
	{
		_callback = callback;
		StartCoroutine(Fade());
	}

	IEnumerator Fade()
	{
		if (!_sr) _sr = GetComponent<SpriteRenderer>();
		while (_sr.color.a < 1)
		{
			_sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, _sr.color.a + fadeOffset);
			yield return new WaitForSeconds(1 / 60);
		}
		if (_callback != null) _callback();
		yield return new WaitForSeconds(gapDuration);
		while (_sr.color.a > 0)
		{
			_sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, _sr.color.a - fadeOffset);
			yield return new WaitForSeconds(1 / 60);
		}
	}
}
