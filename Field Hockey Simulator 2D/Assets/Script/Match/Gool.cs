using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gool : MonoBehaviour
{
    public TextMeshProUGUI textGetGates;
    public int countGetGates;
    public RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        textGetGates.text = countGetGates.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textGetGates.text = countGetGates.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            countGetGates += 1;
        }
    }
}
