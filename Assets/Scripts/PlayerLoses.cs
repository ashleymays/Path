using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    PlayerLoses: Runs when the player falls off the ground or platform.
*/

public class PlayerLoses : MonoBehaviour
{
    private bool isLoading;
    private void Update()
    {
        if (isLoading)
        {
            return;
        }
        // Player is offscreen. Using OnBecameInvisible() method
        // causes problems with loading future scenes when the player wins.
        if (transform.position.y < -13)
        {
            StartCoroutine(ReloadLevel());
        }
    }

    IEnumerator ReloadLevel()
    {
        isLoading = true;
        yield return null;

        AsyncOperation loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!loading.isDone)
        {
            if (loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
            }
            yield return null;
        }
        isLoading = false;
    }
}