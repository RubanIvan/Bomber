using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var btn = GetComponent<Button>();
	    btn.onClick.AddListener(() => QuitApplication());
	}

    public void QuitApplication()
    {
        Application.Quit();
    }
}
