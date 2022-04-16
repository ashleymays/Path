using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load the transition scene.
// Code is from weeklyhow.com: https://weeklyhow.com/how-to-make-transitions-in-unity/

public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 2.0f;
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadLevel();
        }
    }

    void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator DelayLoadLevel(int levelIndex)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelIndex);
    }
}
