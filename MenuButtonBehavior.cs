using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// MenuButtonBehavior : Loads the main menu when the player clicks the menu button at the top left corner.

public class MenuButtonBehavior : MonoBehaviour
{
    private Button menuButton;
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}