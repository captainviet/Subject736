using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kathe : ImmediateItem
{
    public Sprite stunPose;
    public Sprite deadPose;
    public float chaseSpeed;
    private Rigidbody2D _rb;
    private bool _isStunned = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isOnSameFloor = Mathf.Abs(Common.Player().transform.position.y - transform.position.y) < 1f;
        bool playerHasStopped = Common.Player().GetComponent<Rigidbody2D>().velocity.y == 0;
        if (isOnSameFloor && playerHasStopped && !_isStunned)
        {
            Vector2 dir = Common.Player().transform.position.x - transform.position.x > 0 ? Vector2.right : Vector2.left;
            _rb.velocity = dir * chaseSpeed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !_isStunned)
        {
            Common.Player().SetEnableMovement(false);
            Common.BloodOverlay().Activate();
        }
    }

    public void SetStunned(bool isStunned)
    {
        _isStunned = isStunned;
        if (isStunned)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = stunPose;
        }
    }

    public override void Activate(Character activator)
    {
        GameObject selected = Common.Player().inventory.GetSelected();
        if (selected)
        {
            InteractiveItem interactible = selected.GetComponent<InteractiveItem>();
            if (interactible.item == ItemEnum.Syringe)
            {
                Common.Dialog().ToShow("Subject 736 killed.");
                GetComponent<SpriteRenderer>().sprite = deadPose;
            }
            else
            {
                Common.Dialog().ToShow("That does not work.");
            }
        }
    }
}
