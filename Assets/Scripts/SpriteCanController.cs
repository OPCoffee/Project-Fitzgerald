using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCanController : MonoBehaviour
{

    Rigidbody2D rb;
    
    Vector2 direction;

    public float speed = 2.0f;

    public GameObject swordHitbox;

    Collider2D swordCollider;
        // public GameObject swordPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
        swordCollider.enabled = false;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwingSword();
        }
    }

    void FixedUpdate()
    {
        
        rb.velocity = direction.normalized * speed;

    }   

    void SwingSword(){
        swordCollider.enabled = !swordCollider.enabled;
        

    }
}
