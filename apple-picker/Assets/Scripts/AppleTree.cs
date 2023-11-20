using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] GameObject applePrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] float leftAndRightEdge = 10f;
    [SerializeField] float chanceToChangeDirections = 0.1f;
    [SerializeField] float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        StartCoroutine(DropApples());
    }

    void FixedUpdate()
    {
        MoveRandomly();
    }

    IEnumerator DropApples()
    {
        while (true)
        {
            Instantiate(applePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenAppleDrops);
        }
    }

    void MoveRandomly()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        if (pos.x < -leftAndRightEdge || pos.x > leftAndRightEdge)
        {
            ChangeDirection();
        }
        else
        {
            transform.position = pos;
        }

        if (Random.value < chanceToChangeDirections)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        speed *= -1;
    }
}
