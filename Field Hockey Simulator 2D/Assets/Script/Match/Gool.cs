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

    [SerializeField] private Animation animationGoal;

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
            animationGoal.Play();
            ai.GetComponent<EnemyFollow>().Speed = 0;
            StartCoroutine(RestartTime());
        }
    }

    IEnumerator RestartTime()
    {
        yield return new WaitForSeconds(3f);
        ai.GetComponent<EnemyFollow>().Hold = false;
        player.GetComponent<PlayerControl>().Hold = false;
        RestartObject();
        ai.GetComponent<EnemyFollow>().Speed = 4;
    }

    private void RestartObject()
    {
        RestartObject(ball, spawnerBall);
        RestartObject(ai, spawnerAi);
        RestartObject(player, spawnerPlayer);
        RestartObject(goalkeeperOur, spawnerGoalkeeperOur);
        RestartObject(goalkeeperTheir, spawnerGoalkeeperTheir);
    }

    private void RestartObject(GameObject gameObjectMatch, Transform spawner)
    {
        gameObjectMatch.transform.position = spawner.position;
        gameObjectMatch.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
