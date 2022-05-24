using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform ball;
    private int lastX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool payerIsLeft)
    {
        ball = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(ball.position.x);
        if (payerIsLeft)
        {
            transform.position = new Vector3(ball.position.x - offset.x, ball.position.z - offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(ball.position.x + offset.x, ball.position.y + offset.y, transform.position.z);
        }
    }

    void Update()
    {
        if (ball)
        {
            int currentX = Mathf.RoundToInt(ball.position.x);
            if (currentX > lastX) isLeft = false;
            if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(ball.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(ball.position.x - offset.x, ball.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(ball.position.x + offset.x, ball.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPasition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPasition;
        }
    }
}
