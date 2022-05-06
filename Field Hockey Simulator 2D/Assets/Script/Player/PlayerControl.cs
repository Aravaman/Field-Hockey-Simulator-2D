using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveInputVer;
    public float moveInputHor;
    public float speed;

    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Joystick joystickHit;
    public bool hold;
    public float distance = 0.2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnClick(int run) //Ѕег
    {
        speed = run;
    }

    void Update()
    {
        moveInputVer = joystick.Vertical;
        moveInputHor = joystick.Horizontal;
        moveVelocity = new Vector2(moveInputHor * speed, moveInputVer * speed);

        if (hold) //“ут м€ч встаЄт на своЄ место
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        if(facingRight == false && moveInputHor > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInputHor < 0)
        {
            Flip();
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

    public void OnclicHit() //”дар м€чом
    {
        if (hold)
        {
            hold = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(joystickHit.Vertical, joystickHit.Horizontal) * throwObject;
            }
        }
    }

    private void Flip() //ƒл€ пофорота
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
