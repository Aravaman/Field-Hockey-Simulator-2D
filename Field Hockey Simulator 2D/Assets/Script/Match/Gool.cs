using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gool : MonoBehaviour
{
    public TextMeshProUGUI textGetGates;
    public int countGetGates;

    //private Transform ball;
    //public Transform holdPointBall;

    //private Transform ai;
    //public Transform holdPointAi;

    //private Transform player;
    //public Transform holdPointPlayer;

    //private Transform goalkeeperOur;
    //public Transform holdPointGoalkeeperOur;

    //private Transform goalkeeperTheir;
    //public Transform holdPointGoalkeeperTheir;

    void Start()
    {
        textGetGates.text = countGetGates.ToString();

        //ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        //ai = GameObject.FindGameObjectWithTag("AI").GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //goalkeeperOur = GameObject.FindGameObjectWithTag("GoalkeeperOur").GetComponent<Transform>();
        //goalkeeperTheir = GameObject.FindGameObjectWithTag("GoalkeeperTheir").GetComponent<Transform>();
    }

    void Update()
    {
        textGetGates.text = countGetGates.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            countGetGates += 1;
            //ball.gameObject.transform.position = holdPointBall.gameObject.transform.position;
            //ai.gameObject.transform.position = holdPointAi.gameObject.transform.position;
            //player.gameObject.transform.position = holdPointPlayer.gameObject.transform.position;
            //goalkeeperOur.gameObject.transform.position = holdPointGoalkeeperOur.gameObject.transform.position;
            //goalkeeperTheir.gameObject.transform.position = holdPointGoalkeeperTheir.gameObject.transform.position;
        }
    }
}
