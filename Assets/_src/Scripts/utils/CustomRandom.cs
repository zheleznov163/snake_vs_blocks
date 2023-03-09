using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRandom : MonoBehaviour
{
    private System.Random current = new System.Random();

    public int Range(int min, int max)
    {
        int num = current.Next();
        int lenght = max - min;

        num %= num / lenght;
        return min + num;
    }

    public float Range(float min, float max)
    {
        return Mathf.Lerp(min, max, (float)current.NextDouble());
    }
}