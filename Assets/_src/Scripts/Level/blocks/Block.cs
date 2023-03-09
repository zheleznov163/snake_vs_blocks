using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer MeshRenderer;
    public int points;

    public TMPro.TextMeshPro HealthPoints;
    bool isVisible { get => points > 0; }

    public void damage() => setPoints(points - 1);

    public enum Preset
    {
        Easy,
        Normal,
        Hard,
        Harder
    }

    public void setPreset(Preset preset)
    {
        switch (preset)
        {
            case Preset.Easy: setPoints(Random.Range(0, 4)); break;
            case Preset.Normal: setPoints(Random.Range(5, 25)); break;
            case Preset.Hard: setPoints(Random.Range(25, 40)); break;
            case Preset.Harder: setPoints(Random.Range(40, 50)); break;
        }
    }

    public void setPoints(int value)
    {
        points = value;
        updateView();
    }

    //private Color color
    //{
    //    get => MeshRenderer.material.GetColor(ShaderKey.COLOR);
    //    set => MeshRenderer.material.SetColor(ShaderKey.COLOR, value);
    //}

    private void Awake()
    {
        MeshRenderer = GetComponent<Renderer>();
        updateView();
    }

    private void updateView()
    {
        if (isVisible)
            HealthPoints.text = points.ToString();
        else
            destroy();
    }

    public int destroy()
    {
        Destroy(gameObject);
        return points;
    }

    private class ShaderKey
    {
        public static string COLOR = "_Color";
    }
}
