using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ChangeCameraView: Switches between the main orthographic camera and the overhead camera when
    the player presses 1. This script is attached to the overhead camera only.
*/

public class ChangeCameraView : MonoBehaviour
{
    private Camera mainCamera;
    private Camera overheadCamera;
    void Start()
    {
        mainCamera = Camera.main;
        overheadCamera = GetComponent<Camera>();
        overheadCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            // if the main camera is enabled, disable it and enable the overhead camera
            // TODO: have to change where the audio listener is since there can only be one per scene
            if (mainCamera.enabled)
            {
                overheadCamera.enabled = true;
                mainCamera.enabled = false;
            }

            // if the overhead camera is enabled, disable it and enable the main camera
            else if (overheadCamera.enabled)
            {
                mainCamera.enabled = true;
                overheadCamera.enabled = false;
            }
        }
    }
}
