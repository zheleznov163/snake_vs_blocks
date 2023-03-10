using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCounter : MonoBehaviour
{
    private float start = 0;
    private float finish = 0;

    public void setStart(Vector3 position) => start = position.z;
    public void setFinish(Vector3 position) => finish = position.z;

    public float culc(Snake snake) =>
        Mathf.InverseLerp(start, finish, snake.head.transform.position.z);
    
}
