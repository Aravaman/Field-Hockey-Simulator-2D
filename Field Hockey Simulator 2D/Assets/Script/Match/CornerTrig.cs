using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTrig : MonoBehaviour
{
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

    public AudioSource Whistle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            RestartObject();
        }
    }

    public void RestartObject()
    {
        RestartObject(ball, spawnerBall);
        RestartObject(ai, spawnerAi);
        RestartObject(player, spawnerPlayer);
        RestartObject(goalkeeperOur, spawnerGoalkeeperOur);
        RestartObject(goalkeeperTheir, spawnerGoalkeeperTheir);
        Whistle.Play();
    }

    private void RestartObject(GameObject gameObjectMatch, Transform spawner)
    {
        gameObjectMatch.transform.position = spawner.position;
        gameObjectMatch.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
