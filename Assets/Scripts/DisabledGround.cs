using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    DisabledGround: Removes the collider and changes the material of the ground after the player
    leaves the spot. Also tags the disabled ground "Disabled Ground".
*/

public class DisabledGround : MonoBehaviour
{
    private Material disabledMat;
    private Renderer groundRenderer;

    private void Start()
    {
        groundRenderer = GetComponent<Renderer>();
        disabledMat = Resources.Load("Materials/DisabledGroundMat", typeof(Material)) as Material;
    }
    private void OnTriggerExit(Collider other)
    {
        // disable collider on ground component and change its color
        if (other.gameObject.CompareTag("Player"))
        {
            // tag ground as Disabled Ground for Player Wins script
            groundRenderer.gameObject.tag = "Disabled Ground";
            Destroy(GetComponent<Collider>());
            groundRenderer.material = disabledMat;
        }
    }
}
