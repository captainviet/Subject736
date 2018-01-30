using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmConsoleItem : ImmediateItem
{
	public GameObject alarmConsole;
	public GameObject _curConsole = null;
    public override void Activate(Character activator)
    {
		_curConsole = Instantiate(alarmConsole, Common.FocusGroup().transform);
    }

	void Update()
	{
		SetEnabled(_curConsole == null);
	}

	public void SetEnabled(bool isEnabled)
	{
		GetComponent<Collider2D>().enabled = isEnabled;
	}
}
