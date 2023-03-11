using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScreen : MonoBehaviour
{
    public Slider Slider;
    public TMPro.TextMeshProUGUI Score;
    public TMPro.TextMeshProUGUI LevelCurrent;
    public TMPro.TextMeshProUGUI LevelNext;

    public void setScore(int score) =>
        Score.text = score.ToString();

    public void setProgress(float value) =>
        Slider.value = value;

    public void setCurrentLevel(int level)
    {
        LevelCurrent.text = level.ToString();
        LevelNext.text = (level + 1).ToString();
    }
}
