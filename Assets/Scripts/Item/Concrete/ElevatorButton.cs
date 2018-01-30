using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
	public int levelNumber;
    private Elevator _elevator;
    public void SetElevator(Elevator elevator)
    {
		_elevator = elevator;
    }

	void OnMouseDown()
	{
		_elevator.GoToLevel(levelNumber);
		Destroy(transform.parent.gameObject);
	}
}
