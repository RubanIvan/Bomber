using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    private Animator anim;
    private AudioSource asrc;
    // Use this for initialization
    void Start ()
	{
	    anim = GetComponent<Animator>();
        asrc = this.GetComponent<AudioSource>();

        StartCoroutine(playAnimationAndDie());
	}

    private IEnumerator playAnimationAndDie()
    {
        var animtime =  anim.GetCurrentAnimatorStateInfo(0).length * anim.GetCurrentAnimatorStateInfo(0).speed;
        var audioTime = asrc.clip.length;

        yield return new WaitForSeconds(animtime > audioTime ? animtime : audioTime);
        Destroy(this.gameObject);
    }
}
