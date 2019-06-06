using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : Health
{
    [SerializeField]
    private CameraShaker cam;
    public bool isDead;

    public GameObject health2;
    public GameObject health3;

    private AudioSource soundMaker;
    public AudioClip playerHitClip;
    public AudioClip playerLoseClip;

    protected override void Start()
    {
        soundMaker = GetComponent<AudioSource>();
        base.Start();
    }

    public override void reduceHealth(int healthToRemove)
    {
        health -= healthToRemove;
        updateHealthUI();
        checkDeath();
        cam.shakeCamera();
        base.reduceHealth(healthToRemove);
    }

    void updateHealthUI()
    {
        switch (health)
        {
            case 1:
                health2.SetActive(false);
                health3.SetActive(false);
                break;
            case 2:
                health2.SetActive(true);
                health3.SetActive(false);
                break;
            case 3:
                health2.SetActive(true);
                health3.SetActive(true);
                break;
            default:
                break;
        }
    }

    protected override void checkDeath()
    {
        if (isDead == false)
        {
            soundMaker.clip = playerHitClip;
            soundMaker.Play();

            if (health <= 0)
            {
                soundMaker.clip = playerLoseClip;
                soundMaker.Play();
                isDead = true;
                GameManager.instance.youLoseMenu();
            } 
        }
        // You lose screen Play!
        base.checkDeath();
    }
}
