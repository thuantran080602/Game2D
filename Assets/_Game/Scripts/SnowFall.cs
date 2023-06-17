using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFall : MonoBehaviour
{
    public GameObject snowflakePrefabs;
    public float spawnInterval = 0.5f;
    public float spawnRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSnowflakes());
    }

    private IEnumerator SpawnSnowflakes()
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(snowflakePrefabs, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
