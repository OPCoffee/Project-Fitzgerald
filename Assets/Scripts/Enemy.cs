using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Hit Detected " + damage);
    }
}
