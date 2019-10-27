using System.Drawing;
using Assets;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PaddleController _aiPaddle;
    private BallController _ball;
    private Vector3 _bottomLeftCornerPosition;
    private PaddleController _playerPaddle;
    private Vector3 _topRightCornerPosition;
    public BallController ballControllerTemplate;
    public PaddleController paddleControllerTemplate;
    private RectangleF _worldBoundaries;

    // Start is called before the first frame update
    private void Start()
    {
        this._bottomLeftCornerPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        this._topRightCornerPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        this._worldBoundaries = new RectangleF(_bottomLeftCornerPosition.x, this._bottomLeftCornerPosition.y, this._topRightCornerPosition.x, this._topRightCornerPosition.y);

        this._ball = Instantiate(this.ballControllerTemplate);
        this._playerPaddle = Instantiate(this.paddleControllerTemplate);
        this._aiPaddle = Instantiate(this.paddleControllerTemplate);

        this.InitPlayerPaddle(this._playerPaddle);
        this.InitAiPaddle(this._aiPaddle);
    }

    private void InitAiPaddle(PaddleController aiPaddle)
    {
        // This will provide an offset from the right side
        var aiPlayerOffset = Vector3.right * -aiPaddle.transform.localScale.x;
        var centerRightPosition = new Vector3(this._topRightCornerPosition.x, 0, 0);
        var settings = new PaddleInitializationSettings("PlayerPaddleInput", centerRightPosition, aiPlayerOffset, this._worldBoundaries);
        aiPaddle.InitializePaddle(settings);
    }

    private void InitPlayerPaddle(PaddleController playerPaddle)
    {
        // This will provide an offset from the left side
        var leftPlayerOffset = Vector3.right * playerPaddle.transform.localScale.x;
        var centerLeftPosition = new Vector3(this._bottomLeftCornerPosition.x, 0, 0);
        var settings = new PaddleInitializationSettings("AiPaddleInput", centerLeftPosition, leftPlayerOffset, this._worldBoundaries);
        playerPaddle.InitializePaddle(settings);
    }
}