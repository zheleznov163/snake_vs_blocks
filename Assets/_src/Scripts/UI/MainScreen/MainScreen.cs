using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    public TMPro.TextMeshProUGUI record;
    public TMPro.TextMeshProUGUI level;

    public void setLevel(int value) =>
        level.text = value.ToString();

    public void setRecord(int value) =>
        record.text = value.ToString();
}
