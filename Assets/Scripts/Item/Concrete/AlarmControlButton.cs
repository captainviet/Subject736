using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmControlButton : MonoBehaviour
{
	private const float katheOffset = 2.08f;
	private const float elevatorOffset = 3.54f;
	public int buttonNumber;

	void OnMouseDown()
	{
		float katheY = 10f * (buttonNumber - 1) - katheOffset;
		float elevatorY = 10f * (buttonNumber - 1) - elevatorOffset;
		if (buttonNumber == 1)
		{
			GameObject elevator = GameObject.FindGameObjectWithTag("Elevator");
			elevator.transform.position = new Vector2(elevator.transform.position.x, elevatorY);
			Common.Kathe().transform.position = new Vector2(elevator.transform.position.x, katheY);
		}
		else
		{
			Common.Kathe().transform.position = new Vector2(0, katheY);
		}
		Destroy(transform.parent.gameObject);
	}
}
