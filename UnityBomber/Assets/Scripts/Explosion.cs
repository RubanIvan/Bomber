using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    private Animator anim;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    StartCoroutine(playAnimationAndDie());
	}

    private IEnumerator playAnimationAndDie()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length * anim.GetCurrentAnimatorStateInfo(0).speed);
        Destroy(this.gameObject);
    }
}
