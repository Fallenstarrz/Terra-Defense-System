using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Controller : MonoBehaviour
{
    private AudioSource soundMaker;
    public AudioClip shootClip;
    private void Start()
    {
        soundMaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.togglePaused();
        }
        if (Input.GetMouseButtonDown(0))
        {
            soundMaker.clip = shootClip;
            soundMaker.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Enemy>() != null)
                {
                    hit.collider.GetComponent<Health_Enemy>().reduceHealth(1);
                }
            }
        }
    }
}
