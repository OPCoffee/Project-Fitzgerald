using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{

    public float thrust = 10.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Test");
    if(other.gameObject.CompareTag("UnknockEnemy")){ //If it's an unknockable enemy, simply return
        return;
    }

    
        Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
        if (enemy != null)
        {
            Debug.Log("It's here now");
            enemy.isKinematic = false;
            Vector2 difference = (enemy.transform.position - transform.position); //Otherwise take sword hitbox's position and calculate the difference 
            difference = difference.normalized * thrust;
            enemy.AddForce(difference, ForceMode2D.Impulse);
            enemy.isKinematic = true;
        }


    }
}
