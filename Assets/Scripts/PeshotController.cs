using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeshotController : MonoBehaviour
{

    public float speed = 2.0f;

    public bool veritical;

    float timer = 3.0f;

    int direction = 1;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start() //Change to awake when this becomes a prefab
    {
        rb = GetComponent<Rigidbody2D>();
        veritical = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            direction = -direction;

        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (veritical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            //Set animators (later)
        }
        else
        {   
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rb.MovePosition(position);
    }
}
