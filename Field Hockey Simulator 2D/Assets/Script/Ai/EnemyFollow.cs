using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float Speed = 4;
    private Transform ball;
    private Transform gates;

    public bool Hold;
    public float distance = 0.2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;

    private bool facingRight = true;
    GameObject player;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        gates = GameObject.FindGameObjectWithTag("Gates").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!Hold)
        {
            transform.position = Vector2.MoveTowards(transform.position, ball.position, Speed * Time.deltaTime);
        } else if (Hold)
        {
            transform.position = Vector2.MoveTowards(transform.position, gates.position, Speed * Time.deltaTime);
        }

        if (Hold) //“ут м€ч встаЄт на своЄ место
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //ƒл€ подбора м€ча
    {
        if (!Hold)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                Hold = true;
                if (player.GetComponent <PlayerControl>().Hold == true)
                    player.GetComponent<PlayerControl>().Hold = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hold)
        {
            Hold = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gates.position.x, gates.position.y) * throwObject;
            }
        }
    }

    private void FixedUpdate()
    {
        if (facingRight == false && ball.transform.position.x < transform.position.x) //facingRight == false && 
        {
            Flip();
        }
        else if(facingRight == true && ball.transform.position.x > transform.position.x)
        {
            Flip();
        }
        if (Hold && ball.transform.position.x > transform.position.x)
        {
            Flip();
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
