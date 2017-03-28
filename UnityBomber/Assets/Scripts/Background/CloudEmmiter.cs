using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEmmiter : MonoBehaviour
{
    public List<GameObject> Clouds;
    public bool EmitClouds = true;

    public Vector2 FlowDirrection = Vector2.right;
    public int FlowMinSpeed = 5;
    public int FlowMaxSpeed = 20;

    /// <summary>
    /// Sometimes spawn Z coordinate would be decreased by 1. This allow a cloud to hover other objects  
    /// </summary>
    public float ZCoordinate = 1;
    /// <summary>
    /// How far outside the camera
    /// </summary>
    public float XspawnOffset = -1;

    /// <summary>
    /// Min border of spawn frequiency
    /// </summary>
    public int SpawnRangeMin = 1;

    /// <summary>
    /// Max border of spawn frequiency
    /// </summary>
    public int SpawnRangeMax = 15;

    public int TopYBorder = 0;
    public int DownYBorder = 5;


    void Start()
    {
        StartCoroutine("EmitCloudsCoroutine");
    }

    IEnumerator EmitCloudsCoroutine()
    {
        while(EmitClouds)
        {
            if (Clouds.Count <= 0 || !EmitClouds) continue;

            yield return new WaitForSeconds(Random.Range(SpawnRangeMin, SpawnRangeMax));

            int rndInx = Random.Range(0, Clouds.Count);

            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 1f, 0f));
            
            //Sometimes decrease Z to be in front of other objects
            pos.z = ZCoordinate - Random.Range(0,2);

            //pos.x = pos.x + XspawnOffset;
            pos.y = pos.y - Random.Range(TopYBorder, DownYBorder);

            if (Clouds[rndInx] != null)
            {
                var cloud = Instantiate(Clouds[rndInx], pos, Quaternion.identity);
                cloud.transform.parent = this.transform;

                var rb = cloud.GetComponent<Rigidbody2D>();
                rb.AddForce(FlowDirrection * Random.Range(FlowMinSpeed, FlowMaxSpeed));
            }
        }
    }
}
