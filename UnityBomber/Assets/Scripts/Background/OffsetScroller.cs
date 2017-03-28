using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour
{
    public float ScrollSpeed;
    private Vector2 savedOffset;
    private Renderer rd;

    void Start()
    {
        rd = this.GetComponent<Renderer>();
        savedOffset = rd.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * ScrollSpeed, 1);
        float y = Mathf.Sin(Time.time * ScrollSpeed) * 0.5f;
        Vector2 offset = new Vector2(x, y);
        rd.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        rd.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}