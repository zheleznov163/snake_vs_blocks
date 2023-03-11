using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private Rigidbody rb;

    public Rigidbody Rigidbody
    {
        get => rb;
    }

    public HeadTrigger trigger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


}
