using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float dirX, dirY;
    private bool isf = false;
    public float speed;
    public float HP;

    private Rigidbody2D rb;
    //public Animator anin;
    public Joystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        //anin = GetComponent<Animator>();
    }

    void Update()
    {
        //управление и движение
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;

      //if (dirX < 0)
      //      anin.SetBool("isRun", true);

      //  else if (dirX > 0)
      //      anin.SetBool("isRun", true);

        //Поворот
        if (dirX > 0 && isf)
            Flip();
        else if (dirX < 0 && !isf)
            Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void Flip()
    {
        isf = !isf;
        transform.Rotate(0f, 180, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 10;
        }
    }
}