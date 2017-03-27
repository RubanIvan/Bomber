using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOutsideCamera : MonoBehaviour {

    /// <summary>Координаты конца экрана</summary>
    private float BorderPosition;

    void Start()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(-1, -1));
        BorderPosition = Mathf.Abs(v.x);
    }


    void Update()
    {
        if (transform.position.x > BorderPosition+1f)
        {
            Destroy(gameObject);
        }
    }


    void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
}
