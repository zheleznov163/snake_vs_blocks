using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameScreen gameScreen;
    public LoseScreen loseScreen;
    public MainScreen mainScreen;

    public void setScore(int score)
    {
        gameScreen.setScore(score);
        loseScreen.setScore(score);
    }

    public void setProgress(float value)
    {
        gameScreen.setProgress(value);
    }

    public void setRecord(int record)
    {
        loseScreen.setRecord(record);
        mainScreen.setRecord(record);
    }

    public void setCurrentLevel(int value)
    {
        mainScreen.setLevel(value);
        gameScreen.setCurrentLevel(value);
    }
}
