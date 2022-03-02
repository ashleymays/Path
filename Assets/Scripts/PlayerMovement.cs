using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 pivot;
    private Vector3 axis;

    void Update()
    {
        // cube is moving, so don't register any input
        if (isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pivot = new Vector3(transform.position.x, 0f, transform.position.z + 0.5f);
            axis = Vector3.right;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pivot = new Vector3(transform.position.x, 0f, transform.position.z - 0.5f);
            axis = -Vector3.right;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pivot = new Vector3(transform.position.x - 0.5f, 0f, transform.position.z);
            axis = Vector3.forward;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pivot = new Vector3(transform.position.x + 0.5f, 0f, transform.position.z);
            axis = -Vector3.forward;
            StartCoroutine(MoveCube());
        }
    }

    IEnumerator MoveCube()
    {
        isMoving = true;
        for (int i = 0; i < 15f; ++i)
        {
            transform.RotateAround(pivot, axis, 6f);
            yield return new WaitForSeconds(0.0075f);
        }
        isMoving = false;
    }
}
