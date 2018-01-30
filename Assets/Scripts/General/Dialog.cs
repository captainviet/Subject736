using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
  public float durationPerWord;
  public float blankDuration;
  private Image _img;
  private Text _text;
  private Queue<string> _textStack = new Queue<string>();
  private bool _isShowing = false;

  void Start()
  {
    _img = GetComponent<Image>();
    _text = GetComponentInChildren<Text>();
  }

  void Update()
  {
    if (Input.GetMouseButton(1))
    {
      _textStack.Clear();
      StopCoroutine("Activate");
      _SetVisible(false);
      Common.Player().SetEnableMovement(true);
      _isShowing = false;
    }
    Common.Player().SetEnableMovement(!_isShowing);
  }

  public void ToShow(string text)
  {
    _textStack.Enqueue(text);
    if (!_isShowing) StartCoroutine("Activate");
  }
  public void ToShow(string[] text)
  {
    foreach (string line in text) ToShow(line);
  }

  private void _SetVisible(bool isVisible)
  {
    _img.enabled = isVisible;
    _text.enabled = isVisible;
  }

  IEnumerator Activate()
  {
    _isShowing = true;
    Common.Player().SetEnableMovement(false);
    while (_textStack.Count > 0)
    {
      string line = _textStack.Dequeue();
      float duration = line.Split(' ').Length * durationPerWord;
      _text.text = line;

      _SetVisible(true);
      yield return new WaitForSeconds(duration);
      _SetVisible(false);
      yield return new WaitForSeconds(blankDuration);
    }
    _isShowing = false;
    Common.Player().SetEnableMovement(true);
  }
}
