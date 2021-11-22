using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAnimatorController : MonoBehaviour
{
    //Başlangıçta rakiplerin koşma animasyonunu başlatıyoruz
    Animator opponentAnimator;
    string speedHash = "Speed";
    string finishHash = "Finish";
    // Start is called before the first frame update
    void Start()
    {
        opponentAnimator = GetComponent<Animator>();
        SetSpeed(1f);
    }

    // Update is called once per frame
    

    public void SetSpeed(float speed)
    {
        opponentAnimator.SetFloat(speedHash, speed);
    }

    public void EndDance()
    {
        opponentAnimator.SetTrigger(finishHash);
    }
}
