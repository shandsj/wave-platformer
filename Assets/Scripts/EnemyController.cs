using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class EnemyController : MonoBehaviour
{
    public GameObject DeathExplosionPrefab;

    public int BaseScore = 10;

    public GameObject Score;

    private HealthController healthController;

    public void Start()
    {
        this.healthController = GetComponent<HealthController>();
        this.healthController.Death += OnDeath;
    }

    private void OnDeath(object sender, EventArgs e)
    {
        var deathExplosion = GameObject.Instantiate(DeathExplosionPrefab);
        deathExplosion.transform.position = gameObject.transform.position;
        Destroy(gameObject);
        Destroy(deathExplosion, 1);

        Score.GetComponent<ScoreController>().AddScore(BaseScore);
    }    
}
