using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float floorHeight;
    public float speedMultiplier;
    public GameObject levelSelector;
    private GameObject _lvlSelObj;
    private Rigidbody2D _rb;
    private float _targetHeight;
    private float _currentLevel = 3;
    private float _nextLevel = 3;

    void Start()
    {
        _targetHeight = transform.position.y;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y - _targetHeight) < 0.08f)
        {
            _rb.velocity = Vector2.zero;
			// Rigidbody2D playerRb = Common.Player().GetComponent<Rigidbody2D>();
			// playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            _currentLevel = _nextLevel;
            Common.Player().SetEnableMovement(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _lvlSelObj = Instantiate(levelSelector, Common.FocusGroup().transform);
            foreach (Transform btn in _lvlSelObj.transform)
            {
                btn.GetComponent<ElevatorButton>().SetElevator(this);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(_lvlSelObj);
        }
    }

    public void GoToLevel(int nextLevel)
    {
        _nextLevel = nextLevel;
        _targetHeight = transform.position.y + (nextLevel - _currentLevel) * floorHeight;
        Vector2 dir = Mathf.Sign(nextLevel - _currentLevel) > 0 ? Vector2.up : Vector2.down;
        float speed = Mathf.Abs(nextLevel - _currentLevel) * speedMultiplier;
        _rb.velocity = dir * speed;
        // Common.Player().GetComponent<Rigidbody2D>().velocity = dir * speed;
        Common.Player().SetEnableMovement(false);
    }
}
