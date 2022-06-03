using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;

    private Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private Joystick joystickHit;
    private Vector2 moveVelocityHit;
    public bool Hold;
    private float distance = 2f;
    RaycastHit2D hit;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private float throwObject = 5;

    public AudioSource Hit;
    public AudioSource Run;

    GameObject ai;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<FloatingJoystick>();
        joystickHit = FindObjectOfType<FixedJoystick>();
        ai = GameObject.FindGameObjectWithTag("AI");
    }

    public void OnClick(int run) //���
    {
        speed = run;
        Run.Play();
    }

    void Update()
    {
        moveVelocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed); // ��������
        moveVelocityHit = new Vector2(joystickHit.Horizontal, joystickHit.Vertical); // ����

        if (Hold) //��� ��� ����� �� ��� �����
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
            Hit.Play();
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
        if (!Hold)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                Hold = true;
                if(ai.GetComponent<EnemyFollow>().Hold == true)
                    ai.GetComponent<EnemyFollow>().Hold = false;
            }
        }
    }

    public void OnclicHit() //���� �����
    {
        if (Hold)
        {
            Hold = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = moveVelocityHit * throwObject;
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
