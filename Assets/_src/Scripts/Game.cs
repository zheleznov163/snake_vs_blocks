using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    public Plane plane;
    public Snake snake;
    public Camera Camera;
    public Control control;
    public GameSettings settings;
    public DB db;
    public Level level;
    public ScoreCounter score;
    public ProgressCounter progress;

    // UI
    public UIController UIcontroller;

    public enum Status
    {
        Play,
        Win,
        Lose,
        Pause,
    }
    private Status status = Status.Pause;

    public void Awake()
    {
        InitLevel();
    }

    public void Start()
    {
        snake.Died += Lose;
        level.Finish.SnakeFinished += Win;
        StartGame();
    }

    public void OnDestroy()
    {
        snake.Died -= Lose;
        level.Finish.SnakeFinished -= Win;
    }

    private void Update()
    {
        switch (status)
        {
            case Status.Play:
                snake.Run(settings.Speed);
                snake.moveTail(settings.Speed * settings.SpeedTail);
                snake.MoveByX(control.MouseDeltaX * settings.ControllSensetivity);

                Camera.moveTo(snake.head.gameObject);

                UIcontroller.setProgress(progress.culc(snake));
                break;
            case Status.Win:
                snake.Run(settings.Speed);
                snake.moveTail(settings.Speed * settings.SpeedTail);
                break;

        }
    }

    private void FixedUpdate()
    {
        score.ScoreCurrent += snake.damage(settings.DamageCooldown);
    }

    private void InitLevel()
    {
        snake.addTail(db.SnakeLenght != 0 ? db.SnakeLenght : settings.DefaultSnakeLength);
        level.initLevel(settings.startLevel, settings.stepsCount);
    }

    private void StartGame()
    {
        status = Status.Play;
    }

    private void Lose()
    {
        status = Status.Lose;
        Debug.Log("LOSE");
    }

    private void Win()
    {
        status = Status.Win;

        Debug.Log("WIN");
    }
}
