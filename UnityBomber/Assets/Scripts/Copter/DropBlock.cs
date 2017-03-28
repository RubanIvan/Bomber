using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class DropBlock : MonoBehaviour
{
    public GameObject BlockPrefab;
    public int WaitBeforeNextDrop = 1; 
	// Use this for initialization
	void Start () {
        StartCoroutine(ThrowBlock());
    }

    IEnumerator ThrowBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(WaitBeforeNextDrop);
            var clone = Instantiate(BlockPrefab, this.transform,false);
        }
    }
}
