using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public int respownMin = 0;
    public int respownMax = 1;
    public int Loops = 3;

    public int Speed = 1;
    public Vector2 Dirrection = Vector2.right;

    public float TopYBorder = 1f;
    public float DownYBorder = 5f;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Dirrection * Speed;

        StartCoroutine(Laps());
    }

    IEnumerator Laps()
    {
        var camX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x;

        var newPos = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        newPos.z = 0;

        int l = 0;
        while (l< Loops)
        {
            if (this.transform.position.x > camX)
            {
                l++;
                yield return new WaitForSeconds(Random.Range(respownMin, respownMax));

                newPos.y = Random.Range(TopYBorder, DownYBorder);

                this.transform.position = newPos;
            }
            yield return 0;
        }

        Destroy(this.gameObject);
    }
}
