using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwiper : ImmediateItem
{
    public GameObject door;

    public override void Activate(Character activator)
    {
        GameObject selected = Common.Player().inventory.GetSelected();
        if (selected)
        {
            InteractiveItem interactible = selected.GetComponent<InteractiveItem>();
            if (interactible.item == ItemEnum.KeyCard)
            {
                Common.Dialog().ToShow("Door opened.");
                door.GetComponent<Door>().isLocked = false;
            }
            else
            {
                Common.Dialog().ToShow("That does not work.");
            }
        }
        else
        {
            Common.Dialog().ToShow("Keycard required.");
        }
        Common.Player().inventory.ClearSelected(false);
    }
}
