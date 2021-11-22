using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float distanceZ = 10f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.position.z - distanceZ);
    }
}
