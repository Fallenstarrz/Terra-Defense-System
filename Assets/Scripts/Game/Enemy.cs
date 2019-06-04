using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Transform tf;
    [HideInInspector]
    public Health myHealth;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        myHealth = GetComponent<Health>();
        int randomNum = Random.Range(1, 3);
        myHealth.health = randomNum;
    }

    // Update is called once per frame
    void Update()
    {
        // move towards camera
        // on camera hit remove health from camera
        // shake camera
        // flash camera...?
    }
}
