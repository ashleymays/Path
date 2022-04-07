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
    private Renderer goalRenderer;
    private Material disabledMat;

    private void Start()
    {
        goalRenderer = GetComponent<Renderer>();
        disabledMat = Resources.Load("Materials/DisabledGroundMat", typeof(Material)) as Material;
        numOfGrounds = GameObject.FindGameObjectsWithTag("Ground").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            numOfDisabledGrounds = GameObject.FindGameObjectsWithTag("Disabled Ground").Length;
            if (numOfDisabledGrounds == numOfGrounds)
            {
                goalRenderer.material = disabledMat;
                Debug.Log("Won Level!");
                // Destroy(other.gameObject.GetComponent<PlayerMovement>());
                // StartCoroutine(LoadNextLevel());
            }
            else
            {
                Debug.Log("Not done.");
            }
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
