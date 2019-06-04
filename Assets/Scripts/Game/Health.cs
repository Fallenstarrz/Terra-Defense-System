using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void reduceHealth(float healthToRemove)
    {
        health -= healthToRemove;
        checkDeath();
    }

    private void checkDeath()
    {
        if (health <= 0)
        {
            // play particle
            // play sound
            Destroy(this.gameObject);
        }
    }
}
