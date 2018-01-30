using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ImmediateItem
{
    public bool isLocked;
    public GameObject otherDoor;

    public override void Activate(Character activator)
    {
        if (!isLocked)
        {
            Common.Fader().FadeEffect(() => {
                Vector2 targetPos = otherDoor.transform.position;
                Camera.main.GetComponent<CameraMovement>().ToggleHook(true);
                Common.Player().transform.position = targetPos;
                Camera.main.GetComponent<CameraMovement>().ToggleHook(false);
            });
        }
    }
}
