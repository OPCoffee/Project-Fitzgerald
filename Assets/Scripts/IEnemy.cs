using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy //For enemy behavior, may convert this to a parent class?
{

    float health { get; set;}
    public void ToggleMovement();


    public void TakeDamage(float damage);


}
