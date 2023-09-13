using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeshotController : MonoBehaviour
{

    public float speed = 2.0f;

    public bool vertical;

    float changeTime = 3.0f;
    float timer;

    int direction = 1;
    Rigidbody2D rb;

    Animator animator;


    // Start is called before the first frame update
    void Start() //Change to awake when this becomes a prefab
    {
        rb = GetComponent<Rigidbody2D>();
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

        rb.MovePosition(position);
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

}
