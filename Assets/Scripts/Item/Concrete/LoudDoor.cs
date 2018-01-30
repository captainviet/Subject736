using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudDoor : MonoBehaviour
{
    public GameObject blocker;
    public Sprite openedSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Kathe")
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
            Common.Kathe().GetComponent<Kathe>().SetStunned(false);
            float x = GameObject.FindGameObjectWithTag("Elevator").transform.position.x;
            float y = Common.Player().transform.position.y;
            Common.Kathe().transform.position = new Vector2(x, y);
        }
    }
}
