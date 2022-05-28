using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperMove : MonoBehaviour
{
    private Transform ball;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
    }

    void Update()
    {
        if (rb.position.y <= 4f && rb.position.y >= -4f)
            rb.transform.position = new Vector2(transform.position.x, ball.position.y * speed);
        else if (rb.position.y > 4f)
            rb.transform.position = new Vector2(transform.position.x, 4f);
        else if (rb.position.y < -4f)
            rb.transform.position = new Vector2(transform.position.x, -4f);
    }
}
