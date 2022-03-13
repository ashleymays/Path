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
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(player.gameObject);
        StartCoroutine(LoadNextLevel());
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
