using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public float minX = -8f;
    public float maxX = 8f;

    public float spawnZ =8f;
    public float spawnY = 0f;

    public float minDelay = 5f;
    public float maxDelay = 8f;

    void Start()
    {
        Invoke(nameof(Spawn), Random.Range(minDelay, maxDelay));
    }

    void Spawn()
    {
        if (powerUpPrefab == null)
            return;

        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, spawnZ);
        Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
        GameObject obj = Instantiate(powerUpPrefab, pos, rot);

        PowerUp p = obj.GetComponent<PowerUp>();
        if (p != null)
            p.type = Random.Range(1, 4);
            p.Materialize();

        Invoke(nameof(Spawn), Random.Range(minDelay, maxDelay));
    }
}