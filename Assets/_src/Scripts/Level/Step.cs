using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [Range(0, 5)]
    public int blocksCount = 0;
    [Range(0, 5)]
    public int foodValue = 0;

    public bool isWalls = false;

    public Walls walls;
    public Blocks blocks;
    public Foods foods;


    public Step setWalls(bool value)
    {
        isWalls = value;
        return this;
    }

    public Step setBlocksCount(int count)
    {
        blocksCount = count;
        return this;
    }

    public Step setFoodValueCount(int value)
    {
        foodValue = value;
        return this;
    }

    public void render()
    {
        if (blocksCount > 0)
            blocks.renderRandom(blocksCount);
        else
        {
            if (isWalls) walls.renderRandom();
            foods.renderRandom(foodValue);
        }
    }

}
