using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform ball;
    private Transform gates;

    private bool facingRight = true;

    public bool hold;
    public float distance = 0.2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        gates = GameObject.FindGameObjectWithTag("Gates").GetComponent<Transform>();
    }

    void Update()
    {
        if (!hold)
        {
            transform.position = Vector2.MoveTowards(transform.position, ball.position, speed * Time.deltaTime);
        } else if (hold)
        {
            transform.position = Vector2.MoveTowards(transform.position, gates.position, speed * Time.deltaTime);
        }

        if (hold) //“ут м€ч встаЄт на своЄ место
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //ƒл€ подбора м€ча
    {
        if (!hold)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                hold = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hold)
        {
            hold = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gates.position.x, gates.position.y) * throwObject;
            }
        }
    }

    private void FixedUpdate()
    {
        if (ball.transform.position.x > transform.position.x) //facingRight == false && 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Flip() //ƒл€ поворота
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnDrawGizmos() //«она подбора м€ча
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
