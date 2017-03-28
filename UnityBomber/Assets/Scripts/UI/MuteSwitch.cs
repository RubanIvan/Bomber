using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteSwitch : MonoBehaviour
{
    /// <summary>
    /// Variable to pass between scenes
    /// </summary>
    public static bool IsInMute = false;
    public AudioSource AudioSource;

    private Button button;
    // Use this for initialization
    void Start ()
	{
	    button = GetComponent<Button>();
        
	    Image btnImage = button.GetComponent<Image>();
        Sprite enabled = btnImage.sprite;
        Sprite disabled = button.spriteState.disabledSprite;

        MuteSwither(IsInMute, btnImage, enabled, disabled);

        button.onClick.AddListener(() =>
        {
            MuteSwither(!AudioSource.mute, btnImage, enabled, disabled);
        });
	}

    private void MuteSwither(bool muteState, Image btnImage, Sprite enabled, Sprite disabled)
    {
        AudioSource.mute = muteState;
        btnImage.sprite = AudioSource.mute ? disabled : enabled;

        IsInMute = AudioSource.mute;
    }
}
