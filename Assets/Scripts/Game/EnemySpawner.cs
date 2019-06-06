using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTimeCurrent;
    [SerializeField]
    private float spawnTimeMax;
    [SerializeField]
    private GameObject objectToSpawn;

    [SerializeField]
    private Vector3 center;
    [SerializeField]
    private Vector3 size;

    private float timeSinceDifficultyUp;
    public float timeBetweenDifficultyUp;



    // Update is called once per frame
    void Update()
    {
        if (timeSinceDifficultyUp >= timeBetweenDifficultyUp)
        {
            timeSinceDifficultyUp = 0;
            spawnTimeMax -= spawnTimeMax * 0.1f;
        }
        else
        {
            timeSinceDifficultyUp += Time.deltaTime;
        }
        if (spawnTimeCurrent >= 0)
        {
            spawnTimeCurrent -= Time.deltaTime; 
        }
        else
        {
            spawnTimeCurrent = spawnTimeMax;
            Instantiate(objectToSpawn, getSpawnPosition(), objectToSpawn.transform.rotation);
        }
    }

    Vector3 getSpawnPosition()
    {
        Vector3 spawnPos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        return spawnPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0,255,0,255);
        Gizmos.DrawWireCube(center, size);
    }
}
