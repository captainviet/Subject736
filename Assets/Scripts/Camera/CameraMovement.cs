using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float verticalOffset;
	public float triggerDistance;

	void FixedUpdate()
	{
		Rigidbody2D playerRb = Common.Player().GetComponent<Rigidbody2D>();
		ToggleHook(playerRb.velocity.y != 0);
		float diffX = playerRb.transform.position.x - transform.position.x;
		if (Mathf.Abs(diffX) > triggerDistance && diffX * playerRb.velocity.x > 0)
		{
			ToggleHook(true);
		}
		
	}

	public void ToggleHook(bool isHooked)
	{
		if (isHooked) transform.parent = Common.Player().transform;
		else transform.parent = null;
	}

	public void MoveToPlayer(Vector2 playerPos)
	{
		transform.position = new Vector3(playerPos.x, playerPos.y + verticalOffset, transform.position.z);
	}
}
