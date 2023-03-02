using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer MeshRenderer;
    int points;
  
    public int Points
    {
        get => points;
        set {
            updateView(value);
            points = value;
        }
    }

    private Color color
    {
        get => MeshRenderer.material.GetColor(ShaderKey.COLOR);
        set => MeshRenderer.material.SetColor(ShaderKey.COLOR, value);
    }

    private void Awake()
    {
        MeshRenderer = GetComponent<Renderer>();
    }

    private void updateView(int value)
    {
        bool isVisible = value > 0;
        gameObject.SetActive(isVisible);

        if (isVisible)
        {
        }
    }

    private class ShaderKey
    {
        public static string COLOR = "_Color";
    }
}
