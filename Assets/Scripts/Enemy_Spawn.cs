using System.Collections;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform centerPoint;
    public float minRadius = 5f;
    public float maxRadius = 15f;
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnOutsideRadius();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnOutsideRadius()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float distance = Random.Range(minRadius, maxRadius);

        
        float x = Mathf.Cos(angle) * distance;
        float z = Mathf.Sin(angle) * distance;

        Vector3 spawnPosition = centerPoint.position + new Vector3(x, 0.5f, z);
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}