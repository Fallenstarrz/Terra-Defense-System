using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int health;

    protected virtual void Start()
    {
        
    }

    public virtual void reduceHealth(int healthToRemove)
    {

    }

    protected virtual void checkDeath()
    {

    }
}
