using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Persistence;

[RequireComponent(typeof(Canvas))]
public class UIController : MonoBehaviour
{
    public bool IsInMute;
    private AudioSource asrc {get { return GetComponent<AudioSource>(); } }
    void Update()
    {
        asrc.mute = IsInMute;
    }

    // public Button PlayButton;
 //   public Button MuteButton;

	//// Use this for initialization
	//void Start () {
 //       MuteButton.onClick.AddListener(() => IsInMute = !IsInMute);
 //       PlayButton.onClick.AddListener(() => );

 //   }
}
