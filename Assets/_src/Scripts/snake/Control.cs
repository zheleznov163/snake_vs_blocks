using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector3 _previousPosition;

    private float _deltaX;
    public float MouseDeltaX { get => _deltaX; }

    private void Update()
    {
        GetDeltaMousePosition();
    }

    public void GetDeltaMousePosition()
    {
        if (Input.GetMouseButton(0))
            _deltaX = (Input.mousePosition - _previousPosition).x;
        else
            _deltaX = 0;
        _previousPosition = Input.mousePosition;
    }

}