using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    int _scoreCurrent = 0;

    public int ScoreCurrent
    {
        get => _scoreCurrent;
        set => _scoreCurrent = value;
    }
}
