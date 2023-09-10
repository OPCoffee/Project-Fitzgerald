using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Main script in charge of controlling the blue square, LanLan
public class LanLanController : MonoBehaviour
{
    //Fields
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 2.0f;
    public int health = 10;
    public int maxHealth = 10;

    public GameObject swordHitbox;

    Collider2D swordCollider;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0); //Initiate initial look direction

    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {


        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // get new directions
        if (!Mathf.Approximately(direction.x, 0.0f) || !Mathf.Approximately(direction.y, 0.0f)) //Checks if direction.x or direction.y is not equal to 0
        {
            lookDirection.Set(direction.x, direction.y); //If it is not equal to zero, then LanLan must be moving 
            lookDirection.Normalize(); //Normalized to pass as parameters into the animator
        }
        animator.SetFloat("Move X", lookDirection.x); //Pass into animator to correctly change direction
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", direction.magnitude);

        SwordHitbox hbscript = swordHitbox.GetComponent<SwordHitbox>();
        hbscript.changePosition(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swing();
        }
    }

    void FixedUpdate()
    {
        if (!canMove) //canMove is used to temporarily freeze the player when they attack
        {
            rb.velocity = direction.normalized * 0;
        }
        else
        {
            rb.velocity = direction.normalized * speed; //direction vector normalized to give 8 direction movement, rather than freely moving 
        }
    }
    void Swing()
    {
        animator.SetTrigger("Swing");
    }

    void takeDamange(int incomingDamage)
    {
        health -= incomingDamage;
        if (health < 0)
        {
            Debug.Log("LanLan has perished");
        }
    }

    public void addHealth(int addHealth)
    {
        health += addHealth;
        Debug.Log("chealth " + health);
    }
}
