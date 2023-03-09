using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject foodPrefab;


    public void renderRandom(int foodValue)
    {
        if (foodValue > 0)
        {
            Vector3 position = new Vector3(.5f + Random.Range(0, 4), .3f, .5f);
            Vector3 localScale = new Vector3(.5f, .5f, .5f);

            GameObject food = Instantiate(foodPrefab, Vector3.zero, Quaternion.identity, transform);
            food.transform.localScale = localScale;
            food.transform.localPosition = position;

            food.GetComponent<Food>().setValue(foodValue);
        }
    }
}
