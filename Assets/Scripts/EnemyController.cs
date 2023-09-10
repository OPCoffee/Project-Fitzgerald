using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update


    public float healthPoints = 10.0f;

     float timer = 3.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Damage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Hit Detected " + damage);
    }
}
