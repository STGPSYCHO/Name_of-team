using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Transform = UnityEngine.Transform;

public class EnemyFollow : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Rigidbody2D rbEnemy;
    public float speed;
    private Transform player;
    private bool isf = true;
    private GenerateEnemies GE;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        rbPlayer.freezeRotation = true;
        rbEnemy = transform.GetComponent<Rigidbody2D>();
        rbEnemy.freezeRotation = true;
        GE = transform.GetComponent<GenerateEnemies>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        isf = !isf;
        transform.Rotate(0f, 180, 0f);
        Debug.Log("FLIP");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GE.ActivateModule();
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
        
    }
}
