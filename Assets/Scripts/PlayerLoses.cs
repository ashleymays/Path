using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    PlayerLoses: Runs when the player falls off the ground or platform.
*/

public class PlayerLoses : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
    }
    private void Update()
    {
        // Player is offscreen. Using OnBecameInvisible() method
        // causes problems with loading future scenes when the player wins.
        if (player.transform.position.y < -13)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}