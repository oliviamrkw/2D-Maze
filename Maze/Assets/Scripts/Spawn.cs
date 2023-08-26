using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public int minX, maxX, minY, maxY;

    void Start()
    {
        SpawnAtPos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnWithinBounds();
        }
    }

    void SpawnAtPos()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    void SpawnWithinBounds()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}