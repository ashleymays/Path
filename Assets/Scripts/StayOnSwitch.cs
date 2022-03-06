using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    StayOnSwitch: used for making platforms appear only.
 */

public class StayOnSwitch : MonoBehaviour
{
    public GameObject platform;

    void Start()
    {
        platform.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !platform.activeSelf)
        {
            platform.SetActive(true);
        }
    }
}
