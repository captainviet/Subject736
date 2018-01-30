using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedFigure : MonoBehaviour
{

  public Sprite triggerImg;
  private GameObject triggerCharacter;
  // Use this for initialization
  void Start()
  {
    triggerCharacter = GameObject.Find("Nurse");
  }

  // Update is called once per frame
  void Update()
  {

    if (Mathf.Abs(transform.position.y - triggerCharacter.transform.position.y) < 1f)
    {
      triggerCharacter.GetComponent<SpriteRenderer>().sprite = triggerImg;
    }
  }
}
