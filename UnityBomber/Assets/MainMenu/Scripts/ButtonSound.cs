using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour {

	// Use this for initialization
    private Button button;
    private AudioSource asrc;
	void Start ()
	{
	    button = GetComponent<Button>();
	    asrc = GetComponent<AudioSource>();
        button.onClick.AddListener(() => asrc.PlayOneShot(asrc.clip));
	}
}
