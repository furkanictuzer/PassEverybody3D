using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    int rand = 0;
    public float time = 10f;
    public float speed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {        
        //Random sayılar alarak platformun saat yönünde mi yoksa saat yönünün tersinde mi döneceğine karar veriyorum
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.back, 360f, time).setRepeat(-1);
        }
        else if (rand == 2)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360f, time).setRepeat(-1);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody collisionBody = collision.gameObject.GetComponent<Rigidbody>();
        if (rand == 1)
        {
            collisionBody.AddForce( Vector3.right * speed);
        }
        else if (rand == 2)
        {
            collisionBody.AddForce(Vector3.left * speed);
        }

    }

}
