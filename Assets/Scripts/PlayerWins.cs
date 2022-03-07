using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    PlayerWins: Runs when the player reaches the green square (aka the goal).
*/

public class PlayerWins : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Winner!");
        Destroy(player.gameObject.GetComponent<PlayerMovement>());
    }
}
