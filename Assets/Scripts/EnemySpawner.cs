using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int BeginSpawningAtWaveNumber = 1;

    public GameObject SpawnPointsParent;
    private WaveController waveController;
    private GameObject[] spawnPoints;

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        var newSpawn = GameObject.Instantiate(EnemyPrefab);
        newSpawn.transform.position = spawnPoint.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < SpawnPointsParent.transform.childCount; ++i)
        {
            children.Add(SpawnPointsParent.transform.GetChild(i).gameObject);
        }

        spawnPoints = children.ToArray();
    }
}
