using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutMovement : MonoBehaviour
{
    float endPoint = 0.14f;
    float loopTime = 2f;

    void Start()
    {
        LeanTween.moveLocalX(gameObject, endPoint, loopTime).setEaseInOutCubic().setLoopPingPong();
    }

}
