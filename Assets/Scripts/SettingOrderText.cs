using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingOrderText : MonoBehaviour
{
    public SortRunners sortRunners;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    void SetText()
    {
        gameObject.GetComponent<Text>().text = sortRunners.playerRank.ToString();
        //Debug.Log(sortRunners.playerRank);
    }
}
