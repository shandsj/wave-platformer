using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class WaveController : MonoBehaviour
{
    public int Wave = 1;
    public int MaximumEnemiesToSpawnPerCooldownPeriod = 2;
    public float SpawnCooldownTime = 5;
    public int EnemiesToSpawnPerWave = 10;

    /// <summary>
    /// The amount of difficulty increase per wave.
    /// </summary>
    public float WaveDifficultyIncreaseFactor = 1.1f;

    private int enemiesKilledThisWave = 0;
    private bool startingNewWave = false;
    private float lastSpawnTime;
    private List<GameObject> enemies = new List<GameObject>();

    private EnemySpawner[] enemySpawners;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawners = GetComponents<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpawnNeeded())
        {
            SpawnEnemies();
        }

        if (!startingNewWave && this.enemiesKilledThisWave >= this.EnemiesToSpawnPerWave)
        {
            this.startingNewWave = true;

            // New wave
            StartCoroutine(NewWaveCoroutine());
        }
    }

    EnemySpawner GetRandomEnemySpawner()
    {
        return enemySpawners
            .Where(enemySpawner => enemySpawner.BeginSpawningAtWaveNumber <= Wave)
            .ToArray()[UnityEngine.Random.Range(0, enemySpawners.Length)];
    }

    private int GetNumberOfEnemiesLeftToSpawnThisWave()
    {
        return this.EnemiesToSpawnPerWave - this.enemies.Count();
    }

    private int GetNumberOfEnemiesToSpawnThisCooldown()
    {
        return UnityEngine.Random.Range(1, Mathf.Min(this.MaximumEnemiesToSpawnPerCooldownPeriod + 1, this.GetNumberOfEnemiesLeftToSpawnThisWave() + 1));
    }

    private void SpawnEnemies()
    {      
        var numberOfEnemiesToSpawn = this.GetNumberOfEnemiesToSpawnThisCooldown();
        Debug.Log($"Spawning {numberOfEnemiesToSpawn} in wave {this.Wave}");
        for (int i = 0; i < numberOfEnemiesToSpawn; ++i)
        {
            var enemy = GetRandomEnemySpawner().Spawn();
            enemy.GetComponent<HealthController>().Death += this.OnEnemyDeath;
            this.enemies.Add(enemy);
        }

        Debug.Log($"Spawn finished. Enemies left to spawn in wave {this.Wave}: {this.GetNumberOfEnemiesLeftToSpawnThisWave()}");
        
        lastSpawnTime = Time.time;
    }

    private bool IsSpawnNeeded()
    {
        return !startingNewWave && Time.time - lastSpawnTime > SpawnCooldownTime && this.enemies.Count() < this.EnemiesToSpawnPerWave;
    }

    private void OnEnemyDeath(object sender, EventArgs e)
    {
        this.enemiesKilledThisWave++;
    }

    private IEnumerator NewWaveCoroutine()
    {
        yield return new WaitForSeconds(5);

        this.enemiesKilledThisWave = 0;
        this.enemies.Clear();
        this.Wave++;
        this.MaximumEnemiesToSpawnPerCooldownPeriod = Mathf.Max(this.MaximumEnemiesToSpawnPerCooldownPeriod + 1, (int)(this.MaximumEnemiesToSpawnPerCooldownPeriod * this.WaveDifficultyIncreaseFactor));
        // this.SpawnCooldownTime
        this.EnemiesToSpawnPerWave = Mathf.Max(this.EnemiesToSpawnPerWave + 1, (int)(this.EnemiesToSpawnPerWave * this.WaveDifficultyIncreaseFactor));     

        Debug.Log($"Starting new wave {this.Wave}: enemies to spawn {this.EnemiesToSpawnPerWave}");
        this.startingNewWave = false;
    }
}
