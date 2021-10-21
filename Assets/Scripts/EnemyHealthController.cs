using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float Health = 1;
    // public float DamageCooldown = 1;
    public GameObject DeathExplosionPrefab;

    private float lastDamageTime;

    public void Start()
    {
    }

    public void Damage(float amount)
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
            }
        }
    }

    public void Heal(float amount)
    {
        Health += amount;
    }
    
}
