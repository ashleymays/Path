using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 pivot;
    private Vector3 axis;
    private Vector3 fall;
    private Quaternion rotateFall;

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }

    void Update()
    {
        // cube is moving, so don't register any input
        if (isMoving)
        {
            return;
        }

        // cube is not on the ground, make it fall
        if (!isGrounded())
        {
            StartCoroutine(Fall());
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
        for (float i = 0; i < 7.25f; i += 0.3f)
        {
            transform.RotateAround(pivot, axis, i);
            yield return new WaitForSeconds(0.0005f);
        }
        isMoving = false;
    }

    IEnumerator Fall()
    {
        fall = new Vector3(0f, -10f, 0f);
        transform.Translate(fall * Time.deltaTime);
        yield return null;
    }
}
