using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//This class should likely be within sword hitbox. Knockback parameters should be set within enemy scripts
public class Knockback : MonoBehaviour
{

    public float thrust = 10.0f;
    public float knockTime = 30.0f;



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
        if (other.gameObject.CompareTag("UnknockEnemy"))
        { //If it's an unknockable enemy, simply return
            return;
        }


        Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
        if (enemy != null)
        {
            enemy.SendMessage("ToggleMovement");
            enemy.isKinematic = false;
            Vector2 difference = (enemy.transform.position - transform.position); //Otherwise take sword hitbox's position and calculate the difference
            difference = difference.normalized * thrust;
            enemy.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockCo(enemy));
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(0.4f);
            enemy.velocity = Vector2.zero;
            Debug.Log("Test");
            enemy.SendMessage("ToggleMovement");
            enemy.isKinematic = true;
        }
    }
}
