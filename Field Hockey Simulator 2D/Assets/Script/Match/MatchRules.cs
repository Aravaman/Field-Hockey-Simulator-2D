using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchRules : MonoBehaviour
{
    //Варота
    public TextMeshProUGUI textGatesAnAlly;
    public TextMeshProUGUI textGatesTheOpponent;
    public TextMeshProUGUI textTimer;

    public GameObject win;
    public GameObject lose;
    public GameObject nechya;

    [SerializeField] GameObject training;

    // Start is called before the first frame update
    void Start()
    {
        training.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayMath()
    {
        training.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int intGatesAnAlly = Convert.ToInt32(textGatesAnAlly.text);
        int intGatesTheOpponent = Convert.ToInt32(textGatesTheOpponent.text);
        if (float.Parse(textTimer.text) >= 90f)
        {
            if(intGatesAnAlly > intGatesTheOpponent)
            {
                win.SetActive(true);
                Time.timeScale = 0;
            }
            else if(intGatesAnAlly < intGatesTheOpponent)
            {
                lose.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                nechya.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
