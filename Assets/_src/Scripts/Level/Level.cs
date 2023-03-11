using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    enum Preset
    {
        Clear,
        Block,
        Walls,
        Food,
        WallsWithFood
    }

    // ---- Settings -----
    public Finish Finish;
    public GameObject stepPrefab;
    public CustomRandom random;


    public void initLevel(int startPosition, int stepsCount)
    {
        initFinish(startPosition, stepsCount);
        initSteps(startPosition, stepsCount);
    }

    public void initFinish(int startPosition, int stepsCount) =>
        Finish.transform.localPosition = new Vector3(0, 0, startPosition + stepsCount + 6);

    public void initSteps(int startPosition, int stepsCount)
    {
        int stepsAfterBlocks = 0;

        for (int i = 0; i < stepsCount; i++)
        {
            Step step = createStep(new Vector3(0, 0, startPosition + i));
            Preset preset = getPreset();

            if (stepsAfterBlocks > 0)
            {
                stepsAfterBlocks -= 1;
                if (preset == Preset.Block)
                {
                    preset = Preset.Clear;
                }
            }

            switch (preset)
            {
                case Preset.Block:
                    int blocksCount = random.Range(1, 5);
                    step.setBlocksCount(blocksCount);
                    stepsAfterBlocks = blocksCount + 1;
                    break;
                case Preset.Walls:
                    step.setWalls(true);
                    break;
                case Preset.Food:
                    step.setFoodValueCount(random.Range(1, 5));
                    break;
                case Preset.WallsWithFood:
                    step.setWalls(true).setFoodValueCount(random.Range(1, 5));
                    break;
            }

            step.render();
        }
    }

    private Step createStep(Vector3 position) =>
        Instantiate(stepPrefab, position, Quaternion.identity, transform).GetComponent<Step>();

    private Preset getPreset()
    {
        int randomValue = random.Range(0, 8);


        if (randomValue == 1)
            return Preset.WallsWithFood;
        else if (randomValue == 2)
            return Preset.Block;
        else if (randomValue == 3)
            return Preset.Walls;
        else if (randomValue == 4)
            return Preset.Food;
        else
            return Preset.Clear;
    }



}
