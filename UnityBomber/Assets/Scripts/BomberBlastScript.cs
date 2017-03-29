using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BomberBlastScript : MonoBehaviour {

    void Awake()
    {
        GetComponent<AudioSource>().Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AnimationEnd()
    {
        GameObject.Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }

}
