using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Enemy : Health
{
    [SerializeField]
    private SpriteRenderer myRenderer;

    public Color healthColor3;
    public Color healthColor2;
    public Color healthColor1;

    public GameObject deathParticle;
    public GameObject takeHitParticle;

    private AudioSource soundMaker;
    public AudioClip enemyHitClip;
    public AudioClip enemyDieClip;

    protected override void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        soundMaker = GetComponent<AudioSource>();
        changeColor();
        base.Start();
    }

    public override void reduceHealth(int healthToRemove)
    {
        Instantiate(takeHitParticle, transform.position, transform.rotation);
        health -= healthToRemove;
        changeColor();
        checkDeath();
        base.reduceHealth(healthToRemove);
    }

    public void changeColor()
    {
        switch (health)
        {
            case 1:
                myRenderer.color =
                    new Color(healthColor1.r, healthColor1.g, healthColor1.b);
                break;
            case 2:
                myRenderer.color =
                    new Color(healthColor2.r, healthColor2.g, healthColor2.b);
                break;
            case 3:
                myRenderer.color =
                    new Color(healthColor3.r, healthColor3.g, healthColor3.b);
                break;
            default:
                break;
        }
    }

    protected override void checkDeath()
    {
        soundMaker.clip = enemyHitClip;
        soundMaker.Play();
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            soundMaker.clip = enemyDieClip;
            soundMaker.Play();
            Destroy(this.gameObject);
        }
        base.checkDeath();
    }
}
