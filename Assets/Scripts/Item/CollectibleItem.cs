using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : InteractiveItem
{
    public GameObject highlight;
    public GameObject highlightObject { get; private set; }
    private readonly Color _hoverColor = Color.green;
    private SpriteRenderer _sr;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }


    void OnMouseDown()
    {
        if (transform.parent && transform.parent.tag == "Inventory")
        {
            if (!highlightObject)
            {
                highlightObject = Instantiate(highlight, transform.position, new Quaternion());
                highlightObject.transform.parent = transform;
            }
            else Destroy(highlightObject);
        }
        else
        {
            Common.Player().Reach(transform.position, gameObject);
        }
    }
    void OnMouseOver()
    {
        _sr.color = _hoverColor;
    }
    void OnMouseExit()
    {
        _sr.color = Color.white;
    }

    public override void Activate(Character activator)
    {
        activator.inventory.Add(gameObject);
        Common.Dialog().ToShow("Picked up " + Enum.GetName(typeof(ItemEnum), item) + ".");
    }

    public void Clear(bool isDone)
    {
        if (highlightObject)
        {
            if (isDone) Destroy(gameObject);
            else Destroy(highlightObject);
        }
    }
}
