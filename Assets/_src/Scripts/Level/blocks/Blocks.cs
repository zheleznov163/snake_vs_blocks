using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject blockPrefub;

    public void renderRandom(int count)
    {
        switch (count)
        {
            case 1:
                createBlock(Random.Range(0, count - 1)).gameObject.GetComponent<Block>().setPreset(Block.Preset.Normal);
                break;
            case 2:
                int[] indexes = (Random.Range(0, 1) == 0) ? new int[2] { 0, 4 } : new int[2] { 1, 3 };
                foreach (int index in indexes)
                    createBlock(index).gameObject.GetComponent<Block>().setPreset(Block.Preset.Hard);
                break;
            case 3:
            case 4:
                createBlock(1).gameObject.GetComponent<Block>().setPreset(Block.Preset.Easy);
                createBlock(2).gameObject.GetComponent<Block>().setPreset(Block.Preset.Hard);
                createBlock(3).gameObject.GetComponent<Block>().setPreset(Block.Preset.Normal);
                break;
            case 5:
                createBlock(0).gameObject.GetComponent<Block>().setPreset(Block.Preset.Normal);
                createBlock(1).gameObject.GetComponent<Block>().setPreset(Block.Preset.Harder);
                createBlock(2).gameObject.GetComponent<Block>().setPreset(Block.Preset.Easy);
                createBlock(3).gameObject.GetComponent<Block>().setPreset(Block.Preset.Easy);
                createBlock(4).gameObject.GetComponent<Block>().setPreset(Block.Preset.Hard);
                break;

        }
    }

    private GameObject createBlock(int index)
    {
        var position = new Vector3(index + 0.5f, .5f, .5f);
        GameObject block = Instantiate(blockPrefub, Vector3.zero, Quaternion.identity, transform);
        block.transform.localPosition = position;

        return block;
    }


}
