using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform ball;

    private bool facingRight = true;

    private Vector2 moveVelocityHit;
    public bool hold;
    public float distance = 0.2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, ball.position, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (facingRight == false && ball.transform.position.x > transform.position.x)
        {
            Flip();
        }
        else if (facingRight == false && ball.transform.position.x < transform.position.x)
        {
            Flip();
        }
    }

    private void Flip() //Для пофорота
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
