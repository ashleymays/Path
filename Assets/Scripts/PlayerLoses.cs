using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    PlayerLoses: Runs when the player falls off the ground or platform.
*/

public class PlayerLoses : MonoBehaviour
{
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnBecameInvisible()
    {
        // Debug.Log("Player is offscreen.");
    }
}
