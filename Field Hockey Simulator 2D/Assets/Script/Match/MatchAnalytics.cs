using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchAnalytics : MonoBehaviour
{
    public TextMeshProUGUI textGatesAnAlly;
    public TextMeshProUGUI textGatesTheOpponent;

    public TextMeshProUGUI textGatesAnAllyAna;
    public TextMeshProUGUI textGatesTheOpponentAna;

    public TextMeshProUGUI mony;
    public int rules;
    public int finalMony;
    public int getlMony;

    private void Start()
    {
        if (PlayerPrefs.HasKey("mony"))
        {
            getlMony = PlayerPrefs.GetInt("mony");
        }
    }

    void Update()
    {
        textGatesAnAllyAna.text = textGatesAnAlly.text;
        textGatesTheOpponentAna.text = textGatesTheOpponent.text;
        int intGatesAnAllyAna = 1;
        if(Convert.ToInt32(textGatesAnAllyAna.text) != 0)
            intGatesAnAllyAna = Convert.ToInt32(textGatesAnAllyAna.text);
        finalMony = intGatesAnAllyAna * rules;
        mony.text = Convert.ToString(intGatesAnAllyAna * rules);
        PlayerPrefs.SetInt("mony", getlMony + finalMony);
    }
}
