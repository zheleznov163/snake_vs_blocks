using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        UIcontroller.setScore(score.ScoreCurrent);
    }

    private void InitLevel()
    {
        snake.addTail(db.SnakeLength != 0 ? db.SnakeLength : settings.DefaultSnakeLength);
        level.initLevel(settings.startLevel, settings.stepsCount);

        progress.setFinish(level.Finish.transform.position);
        progress.setStart(snake.transform.position);

        score.ScoreCurrent = db.ScoreCurrent;

        UIcontroller.setScore(score.ScoreCurrent);
        UIcontroller.setRecord(db.ScoreRecord);
        UIcontroller.setCurrentLevel(db.LevelIndex + 1);
    }

    public void StartGame()
    {
        status = Status.Play;
        snake.status = Snake.Status.Run;
        Debug.Log("Start game");
        UIcontroller.mainScreen.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Lose()
    {
        status = Status.Lose;

        db.ScoreCurrent = 0;
        db.SnakeLength = 0;

        if (score.ScoreCurrent > db.ScoreRecord)
            db.ScoreRecord = score.ScoreCurrent;

        UIcontroller.setRecord(db.ScoreRecord);
        UIcontroller.loseScreen.gameObject.SetActive(true);

        Debug.Log("LOSE");
    }

    private IEnumerator WaitToRestart(int sec)
    {
        yield return new WaitForSeconds(sec);
        Restart();
    }

    private void Win()
    {
        status = Status.Win;
        db.ScoreCurrent = score.ScoreCurrent;
        db.LevelIndex += 1;
        Debug.Log("WIN");

        StartCoroutine(WaitToRestart(2));
    }

}
