using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinHealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        LanLanController player = other.GetComponent<LanLanController>();

        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.addHealth(1);
                Destroy(gameObject);
            }
        }

    }
}
