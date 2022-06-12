using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonyStart : MonoBehaviour
{
    public TextMeshProUGUI mony;

    private void Awake()
    {
        mony.text = PlayerPrefs.GetInt("mony").ToString();
    }
}
