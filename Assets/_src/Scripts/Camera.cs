using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public void moveTo(GameObject target)
    {
        Vector3 v = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z - 8);
    }
}
