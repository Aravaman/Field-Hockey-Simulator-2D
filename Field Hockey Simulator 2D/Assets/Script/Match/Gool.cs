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

    public GameObject ball;
    public Transform spawnerBall;

    public GameObject ai;
    public Transform spawnerAi;

    public GameObject player;
    public Transform spawnerPlayer;

    public GameObject goalkeeperOur;
    public Transform spawnerGoalkeeperOur;

    public GameObject goalkeeperTheir;
    public Transform spawnerGoalkeeperTheir;

    void Start()
    {
        textGetGates.text = countGetGates.ToString();
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
            //Destroy(collision.gameObject);
            //Instantiate(ball, spawnerBall.position, transform.rotation);
            //Destroy(ai.gameObject);
            //Instantiate(ai, spawnerAi.position, transform.rotation);
            //Destroy(player.);
            //Instantiate(player, spawnerPlayer.position, transform.rotation);
            //Destroy(goalkeeperOur.gameObject);
            //Instantiate(goalkeeperOur, spawnerGoalkeeperOur.position, transform.rotation);
            //Destroy(goalkeeperTheir.gameObject);
            //Instantiate(goalkeeperTheir, spawnerGoalkeeperTheir.position, transform.rotation);
        }
    }
}
