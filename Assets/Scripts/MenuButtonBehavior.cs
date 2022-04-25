using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonBehavior : MonoBehaviour
{
    private Button menuButton;
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OpenMenu);
    }

    void OpenMenu()
    {
        // Load main menu
        SceneManager.LoadScene(0);
    }
}
