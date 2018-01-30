using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodOverlay : MonoBehaviour
{

    public float duration;
    private Image _rb;

    void Start()
    {
        _rb = GetComponent<Image>();
    }

    public void Activate()
    {
        StartCoroutine(TimeDestroy());
    }

    IEnumerator TimeDestroy()
    {
		_rb.enabled = true;
        yield return new WaitForSeconds(duration);
		Common.GameMaster().InitAfterGame();
		_rb.enabled = false;
    }
}
