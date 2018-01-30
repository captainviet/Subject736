using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDream : MonoBehaviour
{
  private Image _img;
  private Button _btn;

  void Start()
  {
    _img = GetComponent<Image>();
    _btn = GetComponent<Button>();
  }

  public void SetEnabled(bool isEnabled)
  {
    _img.enabled = isEnabled;
    _btn.enabled = isEnabled;
  }

  public void EscapeDream()
  {
    Common.Fader(true).FadeEffect(() =>
    {
      Character faith = GameObject.Find("Faith").GetComponent<Character>();
      Character curChar = Common.Player();
      curChar.tag = "Untagged";
      faith.tag = "Player";
      Camera.main.GetComponent<CameraMovement>().MoveToPlayer(faith.transform.position);
      Common.ExitDream().SetEnabled(false);
      faith.Reach((Vector2)faith.transform.position + new Vector2(1.5f, 0), null);
      //
      GameObject.Find("Faith").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    });
  }
}
