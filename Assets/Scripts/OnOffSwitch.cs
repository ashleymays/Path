using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    OnOffSwitch: used for making platforms appear and disappear.
 */

public class OnOffSwitch : MonoBehaviour
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

        else if (other.gameObject.CompareTag("Player") && platform.activeSelf)
        {
            platform.SetActive(false);
        }
    }
}
