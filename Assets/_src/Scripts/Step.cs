using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public Block[] Blocks = new Block[5];

    public Material CubeMaterial;

    public int MinValue = 0;
    public int MaxValue = 45;

    public void setValues()
    {
        foreach (Block block in Blocks)
        {
        }
    }
}
