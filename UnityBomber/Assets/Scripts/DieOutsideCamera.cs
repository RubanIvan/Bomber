using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOutsideCamera : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
