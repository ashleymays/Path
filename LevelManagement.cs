using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManagement : MonoBehaviour
{
    private GameObject player;
    private int numOfGrounds;
    private int numOfDisabledGrounds;
    private Material playerMat;
    private bool changingColor;

    private void Start()
    {
        changingColor = false;
        player = GameObject.Find("Player");
        playerMat = player.GetComponent<Renderer>().material;
        numOfGrounds = GameObject.FindGameObjectsWithTag("Ground").Length;    
    }

    private void Update()
    {
        // player is falling off the platform -> destroy the player and reload the level
        if (player.transform.position.y < 0.9f && !changingColor)
        {
            StartCoroutine(DestroyPlayer());
        }
    }

    // player landed on the goal
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            numOfDisabledGrounds = GameObject.FindGameObjectsWithTag("Disabled Ground").Length;

            // player wins -> go to next level
            if (numOfDisabledGrounds == numOfGrounds)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }

            // player didn't hit all the squares -> destroy the player and reload the level
            else
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            }
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        yield return null;
    }

    IEnumerator DestroyPlayer()
    {
        changingColor = true;
        Color color = playerMat.color; // temp variable for the color; we'll reassign the playerMat color with color
        float val = 0f;
        for (int i = 0; i < 5; ++i)
        {
            color.a = val;
            playerMat.color = color;
            val = (val + 1f) % 2;
            yield return new WaitForSeconds(0.11f);
        }
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
}