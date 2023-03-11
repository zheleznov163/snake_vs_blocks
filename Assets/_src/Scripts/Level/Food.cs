using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Range(0, 5)]
    public int value;
    public TMPro.TextMeshPro valueText;

    public GameObject scaled;


    private bool isVisible
    {
        get => value > 0;
    }

    public void setValue(int v)
    {
        value = v;
        render();
    }

    private void Awake() =>  render();
    private void OnValidate() => render();


    private void Update()
    {
        Animate();
    }

    private void render()
    {
        gameObject.SetActive(isVisible);
        if (isVisible)
            valueText.text = value.ToString();
    }

    // ----------- Animation -----------

    private bool isIncreasing = true;
    public float speedAnimation = .1f;
    public float maxScaled = 1.2f;
    public float minScaled = .8f;

    private void Animate()
    {
        float shift = speedAnimation * Time.deltaTime * (isIncreasing ? 1 : -1);
        //Debug.Log(scaled.transform.localScale.x * shift);

        Vector3 nextScale =  scaled.transform.localScale + scaled.transform.localScale * shift;

        if (nextScale.x > maxScaled || nextScale.x < minScaled)
            isIncreasing = !isIncreasing;

        scaled.transform.localScale = nextScale;
    }





}
