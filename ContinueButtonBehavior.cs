using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButtonBehavior : MonoBehaviour
{
    // make continue button go to level 1 when clicked
    // get button
    // in start, add listener
    // make method to load level 1 (by the ending build order, so index 4 after menu, instructions, credits, and select level)

    private Button contButton;
    
    void Start()
    {
        contButton = GetComponent<Button>();
        contButton.onClick.AddListener(LoadFirstLevel);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(4);
    }
}