using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [Range(0, 2)]
    public float ControllSensetivity = 1;
    [Min(0)]
    public float DamageCooldown = .5f;
    [Min(1)]
    public float Speed = 4;
    [Min(1)]
    public float SpeedTail = 4;
    [Min(0)]
    public int DefaultSnakeLength = 4;
    [Min(5)]
    public int startLevel = 8;
    [Min(5)]
    public int stepsCount = 150;
}
