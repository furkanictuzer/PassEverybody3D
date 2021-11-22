using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody body;

    string speedHash = "Speed";
    string finishHash = "Finish";
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed(body.velocity.magnitude);
    }
    void SetSpeed(float speed)
    {
        playerAnimator.SetFloat(speedHash, speed);
    }

    public void EndDance()
    {
        playerAnimator.SetTrigger(finishHash);
    }
    public void RotatePlayer()
    {
        LeanTween.rotateY(gameObject, 180f, 2);
        SetSpeed(0);
    }
}
