using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    PlayerWins: Runs when the player reaches the green square (aka the goal).
*/

public class LevelManagement : MonoBehaviour
{
    private GameObject player;
    private int numOfGrounds;
    private int numOfDisabledGrounds;
    private Animator animator;
    private Text transitionText;
    public float transitionDelayTime = 2.0f;

    void Awake()
    {
        transitionText = GameObject.Find("Text").GetComponent<Text>(); // get level title text from the transition slide
        transitionText.enabled = true; // show the title text at the start of the level
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        numOfGrounds = GameObject.FindGameObjectsWithTag("Ground").Length;
    }

    private void Update()
    {
        // player is falling off the platform
        if (player.transform.position.y < -11)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
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
                transitionText.enabled = false;
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }

            // player didn't hit all the squares -> reload the level
            else
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            }
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("TriggerTransition"); // start the transition
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelIndex);
    }
}
