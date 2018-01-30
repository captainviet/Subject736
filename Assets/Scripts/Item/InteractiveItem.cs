using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveItem : MonoBehaviour
{
    public ItemEnum item;

    public abstract void Activate(Character activator);

}
