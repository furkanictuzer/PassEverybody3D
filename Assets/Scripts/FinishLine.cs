using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public float destroyTime = 3f;

    public event Action OnLinePass;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            FinishLineOpponent(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            FinishLinePlayer();
        }
    }

    void FinishLineOpponent(GameObject gameObject)
    {
        gameObject.GetComponent<OpponentAnimatorController>().EndDance();
        StartCoroutine(DestroyObject(gameObject));
    }

    void FinishLinePlayer()
    {
        OnLinePass?.Invoke();
    }

    IEnumerator DestroyObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

   
}
