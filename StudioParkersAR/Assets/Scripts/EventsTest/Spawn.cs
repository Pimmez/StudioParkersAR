using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour { 

    public int spawnCount;
    [Range(1, 100)]
    public int spawnSize = 1;
    public float minionOffset = 1;
    public GameObject minion;

    void OnEnable()
    {
        //      EventManager.StartListening ("Spawn", spawnListener);
        EventManager.StartListening("Spawn", Spawner);
    }

    void OnDisable()
    {
        //      EventManager.StopListening ("Spawn", spawnListener);
        EventManager.StopListening("Spawn", Spawner);
    }

    void Spawner()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition();

            Quaternion spawnRotation = new Quaternion();
            spawnRotation.eulerAngles = new Vector3(0.0f, Random.Range(0.0f, 360.0f));
            if (spawnPosition != Vector3.zero)
            {
                Instantiate(minion, spawnPosition, spawnRotation);
            }
        }
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3();
        float startTime = Time.realtimeSinceStartup;
        bool test = false;
        while (test == false)
        {
            Vector2 spawnPositionRaw = Random.insideUnitCircle * spawnSize;
            spawnPosition = new Vector3(spawnPositionRaw.x, minionOffset, spawnPositionRaw.y);
            test = !Physics.CheckSphere(spawnPosition, 0.75f);
            if (Time.realtimeSinceStartup - startTime > 0.5f)
            {
                Debug.Log("Time out placing Minion!");
                return Vector3.zero;
            }
        }
        return spawnPosition;
    }
}
