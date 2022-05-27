using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    DisabledGround: Removes the collider and disables the ground after the player
    leaves the spot. Also tags the disabled ground "Disabled Ground".
*/

public class DisabledGround : MonoBehaviour
{
    private Renderer groundRenderer;

    private void Start()
    {
        groundRenderer = GetComponent<Renderer>();
    }
    private void OnTriggerExit(Collider other)
    {
        // disable collider on ground component and change its color
        if (other.gameObject.CompareTag("Player"))
        {
            // tag ground as Disabled Ground for Player Wins script
            groundRenderer.gameObject.tag = "Disabled Ground";
            Destroy(GetComponent<Collider>());
            groundRenderer.enabled = false;
        }
    }
}