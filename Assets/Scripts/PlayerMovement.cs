using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private bool isFalling;
    private Vector3 pivot;
    private Vector3 axis;
    private Collider playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<Collider>();
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.5f);
    }

    void Update()
    {
        // cube is moving, so don't register any input
        if (isMoving || isFalling)
        {
            return;
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pivot = new Vector3(transform.position.x, 0f, transform.position.z + 0.525f);
            axis = Vector3.right;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pivot = new Vector3(transform.position.x, 0f, transform.position.z - 0.525f);
            axis = -Vector3.right;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pivot = new Vector3(transform.position.x - 0.525f, 0f, transform.position.z);
            axis = Vector3.forward;
            StartCoroutine(MoveCube());
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pivot = new Vector3(transform.position.x + 0.525f, 0f, transform.position.z);
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
            yield return new WaitForSeconds(0.000075f);
        }

        // after a move, check if the player is on the ground or platform
        // if it's not, start falling
        // if it is, allow the player to move again
        if (!isGrounded())
        {
            isFalling = true;
            StartCoroutine(Fall());
        }
        else
        {
            isFalling = false;
            isMoving = false;
        }
    }

    // NOTE: change it so that the while loop has an exit rather than just while (true)
    IEnumerator Fall()
    {
        while (true)
        {
            transform.Rotate(axis * 350f * Time.deltaTime);
            transform.Translate(Vector3.down * 15f * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.0025f);
        }
    }
}
