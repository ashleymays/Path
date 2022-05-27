using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// VolumeButtonBehavior : toggles sound on and off when the player presses the button at the top right corner.

public class VolumeButtonBehavior : MonoBehaviour
{
    private Button volumeButton;
    private AudioSource player;
    public Texture soundOnTexture;
    public Texture muteTexture;
    private CanvasRenderer volumeButtonRenderer;

    void Start()
    {
        volumeButton = GetComponent<Button>();
        player = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        volumeButtonRenderer = GetComponent<CanvasRenderer>();

        volumeButton.onClick.AddListener(SwitchSound);
    }

    void SwitchSound()
    {
        player.mute = !player.mute;

        // sound is off
        if (player.mute == true)
        {
            volumeButtonRenderer.SetTexture(muteTexture);
        }

        // sound is on
        else
        {
            volumeButtonRenderer.SetTexture(soundOnTexture);
        }
    }
}