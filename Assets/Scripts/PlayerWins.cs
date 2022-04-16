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
    public Animator animator;
    public Text transitionText;
    public float transitionDelayTime = 3.0f;

    void Awake()
    {
        transitionText = GameObject.Find("Text").GetComponent<Text>();
        transitionText.enabled = true;
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

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
                transitionText.enabled = false;
                StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
            else
            {
                Debug.Log("Not done.");
            }
        }
    }

    IEnumerator LoadNextLevel(int levelIndex)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelIndex);
    }
}
