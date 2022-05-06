using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSecond : MonoBehaviour
{
    public float timeStart;
    public TextMeshProUGUI textTimer;

    // Start is called before the first frame update
    void Start()
    {
        textTimer.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        textTimer.text = timeStart.ToString("F2");
    }
}
