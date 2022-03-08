using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    PlayerLoses: Runs when the player falls off the ground or platform.
*/

public class PlayerLoses : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}