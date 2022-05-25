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
            ball.transform.position = spawnerBall.position;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ai.transform.position = spawnerAi.position;
            ai.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.transform.position = spawnerPlayer.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            goalkeeperOur.transform.position = spawnerGoalkeeperOur.position;
            goalkeeperOur.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            goalkeeperTheir.transform.position = spawnerGoalkeeperTheir.position;
            goalkeeperTheir.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
