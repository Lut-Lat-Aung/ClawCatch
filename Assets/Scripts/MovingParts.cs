using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingParts : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int moveDirection = 0; // -1 = left, 1 = right, 0 = none
    public float minX = -2.2f;
    public float maxX = 2.2f;

    void Start()
    {
        moveDirection = -1; Debug.Log("going left");

    }

    // Update is called once per frame
    void Update()
    {

        Moving();
        if (transform.position.x == minX)
        {
            moveDirection = 1; Debug.Log("going right");
        }
        if (transform.position.x == maxX)
        {
            moveDirection = -1; Debug.Log("going left");
        }

    }

    void Moving()
    {
        
        Vector3 newPosition = transform.position + new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }
}
