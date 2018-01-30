using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ImmediateItem : InteractiveItem
{

    void OnMouseDown()
    {
        Common.Player().Reach(transform.position, gameObject);
    }
}
