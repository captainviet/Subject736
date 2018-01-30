using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // public bool isAlive;
    public float walkSpeed;
    public Inventory inventory { get; private set; }
    private Rigidbody2D _rb;
    private Vector2 _targetPos;
    private GameObject _reachObj = null;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - _targetPos.x) < 0.05f)
        {
            _rb.velocity = Vector2.zero;
            if (_reachObj)
            {
                InteractiveItem objIntr = _reachObj.GetComponent<InteractiveItem>();
                objIntr.Activate(this);
            }
            _reachObj = null;
        }
        if (tag == "Player")
        {
            GameObject elevator = GameObject.FindGameObjectWithTag("Elevator");
            float elevatorVelocityY = elevator.GetComponent<Rigidbody2D>().velocity.y;
            _rb.velocity = new Vector2(_rb.velocity.x, elevatorVelocityY);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _rb.velocity = Vector2.zero;
    }

    public void Reach(Vector2 position, GameObject target)
    {
        _targetPos = position;
        Vector2 dir = Mathf.Sign(transform.position.x - position.x) > 0 ? Vector2.left : Vector2.right;
        _rb.velocity = dir * walkSpeed;
        _reachObj = target;
    }

    public void SetEnableMovement(bool isEnabled)
    {
        foreach (GameObject reg in GameObject.FindGameObjectsWithTag("Region"))
        {
            reg.GetComponent<Collider2D>().enabled = isEnabled;
        }
    }
}
