using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    StayOffSwitch: used for making platforms disappear only.
 */
public class StayOffSwitch : MonoBehaviour
{
    public GameObject platform;

    void Start()
    {
        platform.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && platform.activeSelf)
        {
            platform.SetActive(false);
        }
    }
}
