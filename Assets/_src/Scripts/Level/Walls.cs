using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    public GameObject wallPrefab;


    public void renderRandom()
    {
        createWall(Random.Range(1, 4));
    }

    private void createWall(int value)
    {
        Vector3 position = new Vector3(value, .5f, .5f);
        GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.identity, transform);
        wall.transform.localPosition = position;
    }


}
