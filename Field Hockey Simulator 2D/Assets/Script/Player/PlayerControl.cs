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

    private Animator anim;

    GameObject ai;

    private bool facingRight = true;

    private BoxCollider2D col;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<FloatingJoystick>();
        joystickHit = FindObjectOfType<FixedJoystick>();
        ai = GameObject.FindGameObjectWithTag("AI");
        col = GetComponent<BoxCollider2D>();
    }

    public void OnClick(int run) //Ѕег
    {
        speed = run;
        Run.Play();
    }

    void Update()
    {
        moveVelocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed); // ƒвижение
        moveVelocityHit = new Vector2(joystickHit.Horizontal, joystickHit.Vertical); // ”дар

        if (Hold) //“ут м€ч встаЄт на своЄ место
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

        if(moveVelocity == new Vector2(0, 0))
        {
            anim.SetBool("isRuning", false);
        }
        else
        {
            anim.SetBool("isRuning", true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //ƒл€ подбора м€ча
    {
        if (!Hold)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.right * transform.localScale.x, distance);
            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                Hold = true;
                if(ai.GetComponent<EnemyFollow>().Hold == true)
                    ai.GetComponent<EnemyFollow>().Hold = false;
            }
        }
    }

    public void OnclicHit() //”дар м€чом
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

    private void Flip() //ƒл€ поворота
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
