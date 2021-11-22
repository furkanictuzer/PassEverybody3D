using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class SortRunners : MonoBehaviour
{
    private List<GameObject> runners=new List<GameObject>();
    public GameObject player;
    public GameManager gameManager;
    float playerIndex= 1f;   

    public float playerRank = 1f;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            runners.Add(transform.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPaintStage && !gameManager.isFinish)
        {
            GetPlayerRank();
        }
        
        
    }
    void GetPlayerRank()
    {
        runners.Sort((p1, p2) => p1.gameObject.transform.position.z.CompareTo(p2.gameObject.transform.position.z));
        playerIndex =runners.FindIndex(a => a.gameObject == player);
        playerRank = runners.Count - playerIndex;
    }
}
