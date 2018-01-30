using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
  public bool destroyAfterSeen;
  public SubtitleDef sub;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag != "Player")
    {
      return;
    }
    Common.Player().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    string[] subLines = SubtitleParser.Get(sub);
    print("Playing" + sub);
    Common.Dialog().ToShow(subLines);
    if (destroyAfterSeen) Destroy(gameObject);
  }
}
