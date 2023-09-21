using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Degenerated class that no longer has any functionality due to being delegated to a simple hitbox rather than a sword gameObject
public class Sword : MonoBehaviour
{
    // Start is called before the first frame update



    float timer = 0.25f;
    Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0)  
        {
            Destroy(gameObject);
        }

        // Debug.Log(transform.parent.position.x);
    }

    public void Swing(){
        

    }

    void OnCollisionEnter2D(Collision2D other){
        
    }
}
