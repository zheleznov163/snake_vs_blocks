using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.HableCurve;

public class Snake : MonoBehaviour
{
    public GameObject segmentPrefab;
    public Head head;
    public TMPro.TextMeshPro lengthText;

    public enum Status
    {
        Run,
        Stop,
        Bonus,
    }

    private Status _status = Status.Stop;
    public Status status
    {
        get => _status;
        set => _status = value;
    }

    public event Action Died;

    private void Start()
    {
        head.trigger.EatingFood += Eat;
    }

    private void OnDestroy()
    {
        head.trigger.EatingFood -= Eat;
    }

    private void Update()
    {
        renderTailLenghtText();
    }


    // ------------ Хвост -----------------

    private List<GameObject> listSegments = new List<GameObject>();
    private Vector3 getNextSegmentPosition(Vector3 current) => new Vector3(current.x, current.y, current.z - .3f);

    private void renderTailLenghtText()
    {
        lengthText.text = listSegments.Count.ToString();
    }


    public void moveTail(float speed)
    {
        var target = head.gameObject;
        var step =  speed * Time.deltaTime;

        for (int i = 0; i < listSegments.Count; i++)
        {
            var current = listSegments[i];
            var targetPosition = getNextSegmentPosition(target.transform.position);
            current.transform.position = Vector3.Lerp(current.transform.position, targetPosition, step);
            target = current;
        }
    }

    private GameObject tailTip
    {
        get => listSegments.Count > 0 ? listSegments[listSegments.Count - 1] : head.gameObject;
    }

    public void addTail(int length)
    {
        var current = tailTip.transform.position;
        for (int i = 0; i < length; i++)
        {
            var nextPosition = getNextSegmentPosition(current);
            var segment = Instantiate(segmentPrefab, nextPosition, Quaternion.identity, transform);
            listSegments.Add(segment);
            current = nextPosition;
        }
    }

    private void removeTail(int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (listSegments.Contains(tailTip))
            {
                var segment = tailTip;
                listSegments.Remove(segment);
                Destroy(segment);
            }
        }
    }

    public void Eat(Food food)
    {
        addTail(food.value);
        food.setValue(0);
    }

    // ----------- Движение ---------------

    public void Run(float speed)
    {
        if (status != Status.Stop)
            head.Rigidbody.velocity = new Vector3(0, 0, speed);
    }

    public float crop = 100;
    public float maxLeft = .15f;
    public float maxRight = 4.85f;

    public void MoveByX(float deltaX)
    {
        if (deltaX != 0 && status != Status.Stop)
        {
            var x = deltaX / crop;

            var nextX = x + head.transform.position.x;
            if (nextX < maxLeft || nextX > maxRight)
                return;

            head.transform.position = head.transform.position + new Vector3(x, 0, 0);
        }
    }

    // ----------- Урон -------------

    private float timerCooldown = 0;

    public int damage(float cooldown)
    {
        // -----
        if (!head.trigger.LastTouched || status == Status.Stop)
            return 0;

        if (timerCooldown > 0)
        {
            timerCooldown -= Time.fixedDeltaTime;
        }
        else if (listSegments.Count > 0)
        {
            Debug.Log("Damage");
            timerCooldown = cooldown;
            head.trigger.LastTouched.damage();
            removeTail(1);
            return 1;
        }
        else
        {
            Died?.Invoke();
        }
        return 0;
        // --------
    }
}
