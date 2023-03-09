using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI recordText;

    public void setScore(int score) =>
        scoreText.text = score.ToString();

    public void setRecord(int record) =>
        recordText.text = record.ToString();
}
