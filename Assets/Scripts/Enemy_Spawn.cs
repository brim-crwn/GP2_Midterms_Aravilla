using System.Collections;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private Transform centerPoint;

    private float minRadius = 50f;
    private float maxRadius = 50f;
    private float spawnInterval = 3f;

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

        int randomIndex = Random.Range(0, objectPrefabs.Length);

        Instantiate(objectPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}