using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorStickObstacle : MonoBehaviour
{
    public float force = 50f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Opponent"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-force * new Vector3(0f, 0, 1));            
        }       
    }
}
