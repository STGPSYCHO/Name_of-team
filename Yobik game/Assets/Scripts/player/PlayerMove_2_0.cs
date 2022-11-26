using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_2_0 : MonoBehaviour
{
    public float dirX, dirY;
    public bool isf = true;
    public float speed;

    private Rigidbody2D rb;
    private Animator anin;
    public Joystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        //���������� � ��������
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;

       


      if (dirX < 0)
            anin.SetBool("isRun", true);

        else if (dirX < 0)
            anin.SetBool("isRun", true);

        //�������
        if (dirX > 0 && isf)
            Flip();
        else if (dirX < 0 && isf)
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
}