using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : ImmediateItem
{
    public GameObject ray;
    public override void Activate(Character activator)
    {
        ray.GetComponent<FaderMask>().FadeEffect(() => {
            ray.GetComponent<Collider2D>().enabled = true;
        });
    }
}
