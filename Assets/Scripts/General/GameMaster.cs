using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    enum State { BeforeGame, InGame, AfterGame }

    public GameObject canvas;
    public GameObject startScreen;
    public GameObject endScreen;
    private State _curState = State.BeforeGame;
    private GameObject _curStartScreen = null;
    private GameObject _curEndScreen = null;

    void Start()
    {
        InitBeforeGame();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (_curState)
            {
                case State.BeforeGame:
                    InitInGame();
                    break;
                case State.AfterGame:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                default:
                    break;
            }
        }
    }

    public void InitBeforeGame()
    {
        Common.Fader().FadeEffect(() =>
        {
            _curState = State.BeforeGame;
            Common.Player().SetEnableMovement(false);
            if (_curEndScreen) Destroy(_curEndScreen);
            _curStartScreen = Instantiate(startScreen, canvas.transform);
        });
    }
    public void InitInGame()
    {
        Common.Fader().FadeEffect(() =>
        {
            Vector2 playerPos = Common.Player().transform.position;
            Vector3 cameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(playerPos.x, cameraPos.y, cameraPos.z);
            _curState = State.InGame;
            Common.Player().SetEnableMovement(true);
            Common.Player().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (_curStartScreen) Destroy(_curStartScreen);
        });
    }
    public void InitAfterGame()
    {
        Common.Fader().FadeEffect(() =>
        {
            _curState = State.AfterGame;
            Common.Player().SetEnableMovement(false);
            _curEndScreen = Instantiate(endScreen, canvas.transform);
        });
    }
}
