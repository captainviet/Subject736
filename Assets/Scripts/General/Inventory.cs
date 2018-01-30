using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public float padding;
    private List<GameObject> _pool = new List<GameObject>();


    public void Add(GameObject target)
    {
        // add to pool
        _pool.Add(target);
        // determine position
        float xPos = transform.position.x - padding * (_pool.Count - 1);
        target.transform.position = new Vector2(xPos, transform.position.y);
        target.transform.parent = transform;
    }

    public GameObject GetSelected()
    {
        foreach (Transform item in transform)
        {
            if (item.GetComponent<CollectibleItem>().highlightObject) return item.gameObject;
        }
        return null;
    }
    public void ClearSelected(bool isDone)
    {
        // Clear used
        foreach (Transform item in transform)
        {
            item.GetComponent<CollectibleItem>().Clear(isDone);
        }
        // Move the rest to the right
        if (isDone)
        {
            int oldCount = _pool.Count;
            _pool = _pool.Where(item => item != null).ToList();
            float xOffset = (oldCount - _pool.Count) * padding;
            _pool.ForEach(item => {
                item.transform.position = new Vector2(item.transform.position.x + xOffset, item.transform.position.y);
            });
        }
    }
}
