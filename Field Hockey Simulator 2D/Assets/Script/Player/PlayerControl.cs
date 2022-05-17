using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Joystick joystickHit;
    private Vector2 moveVelocityHit;
    public bool hold;
    public float distance = 0.2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;

    public float offset;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnClick(int run) //���
    {
        speed = run;
    }

    void Update()
    {
        moveVelocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed); // ��������
        moveVelocityHit = new Vector2(joystick.Horizontal, joystick.Vertical); // ����

        if (hold) //��� ��� ����� �� ��� �����
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        if(facingRight == false && moveVelocity.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveVelocity.x < 0)
        {
            Flip();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //��� ������� ����
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

    public void OnclicHit() //���� �����
    {
        if (hold)
        {
            hold = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity += moveVelocityHit * throwObject;
            }
        }
    }

    private void Flip() //��� ��������
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnDrawGizmos() //���� ������� ����
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
