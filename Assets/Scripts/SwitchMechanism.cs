using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMechanism : MonoBehaviour
{
    private Rigidbody switchRB;
    public GameObject platform;
    public MeshRenderer platformMR;
    private bool isOn;

    void Start()
    {
        platformMR.enabled = false;
        switchRB = GetComponent<Rigidbody>();
        platformMR = platform.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!isOn)
        {
            platformMR.enabled = false;
        }
        else
        {
            platformMR.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isOn = true;
    }
}
