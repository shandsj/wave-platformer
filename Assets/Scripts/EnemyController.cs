using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class EnemyController : MonoBehaviour
{
    public GameObject DeathExplosionPrefab;

    public int BaseScore = 10;

    private HealthController healthController;
    private ScoreController[] scoreControllers;

    private void Awake()
    {
        this.healthController = GetComponent<HealthController>();
        this.healthController.Death += OnDeath;

        this.scoreControllers = FindObjectsOfType<ScoreController>();
    }

    private void OnDeath(object sender, EventArgs e)
    {
        var deathExplosion = GameObject.Instantiate(DeathExplosionPrefab);
        deathExplosion.transform.position = gameObject.transform.position;
        Destroy(gameObject);
        Destroy(deathExplosion, 1);

        
        foreach (var scoreController in this.scoreControllers)
        {
            scoreController.AddScore(BaseScore);
        }
    }    
}
