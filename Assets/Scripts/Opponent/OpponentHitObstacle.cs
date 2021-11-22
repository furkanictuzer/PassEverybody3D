using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHitObstacle : MonoBehaviour
{
    Vector3 initalPos;
    public float initialRangeX;
    public float radiusIncrease = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        initalPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(Random.Range(-initialRangeX, initialRangeX), initalPos.y, initalPos.z);     
        }
    }
}
