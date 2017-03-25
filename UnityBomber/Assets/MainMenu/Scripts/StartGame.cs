using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGame : MonoBehaviour {

	// Use this for initialization
    private Button btn { get { return GetComponent<Button>(); } }
	void Start () {
        btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("bomber");
            }
        );
	}
}
