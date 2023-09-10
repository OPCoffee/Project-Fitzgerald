using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{

    public Collider2D swordCollider;
    public float swordDamage = 1f;
    //Possible refactor, get/set direction?
    Vector3 faceRight = new Vector3(0.4f, 0, 0); // or Vector3.
    Vector3 faceLeft = new Vector3(-0.4f, 0, 0);
    Vector3 faceUp = new Vector3(0, 1, 0);
    Vector3 faceDown = new Vector3(0, -1, 0);
    // Start is called before the first frame update
    void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword collider not set");
        }
        swordCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePosition(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 0) //no direction change
        {
            return;
        }
        if (direction.x == 1 && direction.y == 0) //look right
        {
            gameObject.transform.localPosition = faceRight;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (direction.x == -1 && direction.y == 0) //look left
        {   
            gameObject.transform.localPosition = faceLeft;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (direction.x == 0 && direction.y == 1) //look up
        {   
            gameObject.transform.localPosition = faceUp;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (direction.x == 0 && direction.y == -1) //look down
        {
            gameObject.transform.localPosition = faceDown;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Pass direction from parent, change relative psotion with gameObject.transform.localPosition = direction;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("Damage", swordDamage);
    }

    public void Yell()
    {
        Debug.Log("what the heck");
    }
}
