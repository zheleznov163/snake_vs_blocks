using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action SnakeFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Snake snake))
            SnakeFinished?.Invoke();
    }
}
