using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health_Enemy))]
public class Enemy : MonoBehaviour
{
    private Transform tf;
    [HideInInspector]
    public Health_Enemy myHealth;

    public float moveSpeed;
    public Transform targetPos;

    // Use this for initialization
    void Awake()
    {
        tf = GetComponent<Transform>();
        myHealth = GetComponent<Health_Enemy>();
        int randomNum = Random.Range(1, 4);
        myHealth.health = randomNum;
        targetPos = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPos.position - tf.position;
        tf.Translate(direction * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Controller>() != null)
        {
            other.gameObject.GetComponent<Health>().reduceHealth(1);
            Destroy(this.gameObject);
        }
    }
}
