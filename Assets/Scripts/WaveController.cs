using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class WaveController : MonoBehaviour
{
    public int Wave = 1;
    public int MinimEnemiesToSpawnPerCooldownPeriod = 1;
    public int MaximumEnemiesToSpawnPerCooldownPeriod = 5;
    public float SpawnCooldownTime = 5;

    private float lastSpawnTime;


    private EnemySpawner[] enemySpawners;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawners = GetComponents<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpawnTime())
        {
            Spawn();
        }
    }

    EnemySpawner GetRandomEnemySpawner()
    {
        return enemySpawners
            .Where(enemySpawner => enemySpawner.BeginSpawningAtWaveNumber >= Wave)
            .ToArray()[Random.Range(0, enemySpawners.Length)];
    }

    void Spawn()
    {
        var numberOfEnemiesToSpawn = Random.Range(MinimEnemiesToSpawnPerCooldownPeriod, MaximumEnemiesToSpawnPerCooldownPeriod + 1);
        for (int i = 0; i < numberOfEnemiesToSpawn; ++i)
        {
            GetRandomEnemySpawner().Spawn();
        }
        
        lastSpawnTime = Time.time;
    }

    bool IsSpawnTime()
    {
        return Time.time - lastSpawnTime > SpawnCooldownTime;
    }
}
