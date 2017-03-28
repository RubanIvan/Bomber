using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackToMainMenu : MonoBehaviour
{
    public Score Score;
    private Button btn { get { return GetComponent<Button>(); } }

	void Start ()
	{
        
        btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
	}
}
