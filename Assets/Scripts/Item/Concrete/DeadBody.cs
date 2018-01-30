using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : ImmediateItem
{
  public GameObject dreamPlayer;
  public override void Activate(Character activator)
  {
    Common.Fader(true).FadeEffect(() =>
    {
      Character curPlayer = Common.Player();
      curPlayer.tag = "Untagged";
      dreamPlayer.tag = "Player";
      Camera.main.GetComponent<CameraMovement>().MoveToPlayer(dreamPlayer.transform.position);
      Common.ExitDream().SetEnabled(true);
      GetComponent<Collider2D>().enabled = false;
      //
      GameObject.Find("Faith").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    });
  }
}
