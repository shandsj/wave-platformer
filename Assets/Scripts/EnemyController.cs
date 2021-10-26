using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 1;
    // public float DamageCooldown = 1;
    public GameObject DeathExplosionPrefab;

    public int BaseScore = 10;

    public GameObject Score;

    private float lastDamageTime;

    public void Start()
    {
    }

    public void ApplyDamage(float amount)
    {
        // if (Time.time - lastDamageTime > DamageCooldown)
        {
            lastDamageTime = Time.time;
            Health -= amount;

            if (Health <= 0)
            {
                var deathExplosion = GameObject.Instantiate(DeathExplosionPrefab);
                deathExplosion.transform.position = gameObject.transform.position;
                Destroy(gameObject);
                Destroy(deathExplosion, 1);

                Score.GetComponent<ScoreController>().AddScore(BaseScore);
            }
        }
    }

    public void Heal(float amount)
    {
        Health += amount;
    }
    
}
