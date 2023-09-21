using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeshotController : Enemy
{

    public float speed = 2.0f;

    public bool vertical;

    float changeTime = 3.0f;
    float timer;

    int direction = 1;

    Rigidbody2D rb;

    bool canMove;
    Animator animator;


    // Start is called before the first frame update
    void Start() //Change to awake when this becomes a prefab
    {
        this.health = 10.0f;
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        vertical = true;
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        //Movement will be specific to each enemy. Because of this IEnemy may not be needed anymore
        Vector2 position = rb.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        if (canMove == true)
        {
            rb.MovePosition(position);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        LanLanController player = other.gameObject.GetComponent<LanLanController>();
        if (player != null)
        {
            player.takeDamage(1);
        }
    }

    //Implement knockback
    // public void TakeDamage(float damage)
    // {
    //     this.health -= damage;

    //     if (this.health < 0)
    //     {
    //         Destroy(gameObject);
    //     }
    //     Debug.Log("Hit Detected " + damage);
    // }

    public void ToggleMovement()
    {
        Debug.Log("ToggleMovement");
        canMove = !canMove;
    }

}
