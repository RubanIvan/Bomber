using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteSwitch : MonoBehaviour
{

    private Button button;
    private UIController uiv;
    private SpriteState invertState = new SpriteState();
    private SpriteState originalState = new SpriteState();
    // Use this for initialization
    void Start ()
	{
	    button = GetComponent<Button>();
	    uiv = GetComponentInParent<UIController>();

	    Image btnImage = button.GetComponent<Image>();
        Sprite enabled = btnImage.sprite;
        Sprite disabled = button.spriteState.disabledSprite;

        button.onClick.AddListener(() =>
        {
            uiv.IsInMute = !uiv.IsInMute;
            btnImage.sprite = uiv.IsInMute ? disabled : enabled;
        });
	}
}
