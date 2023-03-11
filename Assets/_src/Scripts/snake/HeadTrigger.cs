using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HeadTrigger : MonoBehaviour
{
    private List<Block> touchedBlocks = new List<Block>();
    public Block LastTouched
    {
        get {
            int length = touchedBlocks.Count - 1;
            return length >= 0 ? touchedBlocks[length] : null; 
        }
    }

    public event Action<Food> EatingFood;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Block block))
            touchedBlocks.Remove(block);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
            touchedBlocks.Add(block);
        else if (other.TryGetComponent(out Food food))
            EatingFood?.Invoke(food);
    }
}
