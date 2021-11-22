using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacles : MonoBehaviour
{
    float edgePoint =0f ;
   
    public float loopTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        edgePoint = -transform.position.x;
        LeanTween.moveX(gameObject, edgePoint, loopTime).setEaseInOutCubic().setLoopPingPong();
    }
}
