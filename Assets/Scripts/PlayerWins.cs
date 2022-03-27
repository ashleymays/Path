using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    PlayerWins: Runs when the player reaches the green square (aka the goal).
*/

public class PlayerWins : MonoBehaviour
{
    private int numOfGrounds;
    private int numOfDisabledGrounds;

    private void Start()
    {
        numOfGrounds = GameObject.FindGameObjectsWithTag("Ground").Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        // get the array of grounds tagged "Ground"
        // get the array of grounds tagged "Disabled Ground"
        // if the array sizes are equal, then the player wins
            // add one since it won't take the most recently disabled ground into account
            // TODO: FIX THE ABOVE
        numOfDisabledGrounds = GameObject.FindGameObjectsWithTag("Disabled Ground").Length + 1;
        if (numOfDisabledGrounds == numOfGrounds)
        {
            Destroy(other.gameObject.GetComponent<PlayerMovement>());
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return null;

        AsyncOperation loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!loading.isDone)
        {
            if (loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
