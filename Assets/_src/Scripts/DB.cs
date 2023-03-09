using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DB : MonoBehaviour
{
    public int ScoreRecord
    {
        get => PlayerPrefs.GetInt(DB.SCORE_RECORD, 0);
        set => SetInt(DB.SCORE_RECORD, value);
    }

    public int ScoreCurrent
    {
        get => PlayerPrefs.GetInt(DB.SCORE_CURRENT, 0);
        set => SetInt(DB.SCORE_CURRENT, value);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(DB.LEVEL_INDEX, 0);
        set => SetInt(DB.LEVEL_INDEX, value);
    }

    public int SnakeLenght
    {
        get => PlayerPrefs.GetInt(DB.SNAKE_LENGTH, 0);
        set => SetInt(DB.SNAKE_LENGTH, value);
    }

    int GetInt(string key) => PlayerPrefs.GetInt(key, 0);
    void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    readonly static string SCORE_RECORD = "Score Record";
    readonly static string SCORE_CURRENT = "Score Current";
    readonly static string LEVEL_INDEX = "Level Index";
    readonly static string SNAKE_LENGTH = "Snake Length";
}
