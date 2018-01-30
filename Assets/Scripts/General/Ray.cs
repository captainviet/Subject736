using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Kathe")
        {
            other.GetComponent<Kathe>().SetStunned(true);
						GetComponent<Collider2D>().enabled = false;
        }
    }
}
