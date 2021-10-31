using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    /// <summary>
    /// The amount of health.
    /// </summary>
    public int Health = 3;

    /// <summary>
    /// The amount of time the game object is immune to damage after being damaged.
    /// </summary>
    public float DamageCooldown = 1;

    /// <summary>
    /// Indicates whether the attached entity is dead.
    /// </summary>
    public bool IsDead = false;

    /// <summary>
    /// Raised when health reaches zero.
    /// </summary>
    public event EventHandler Death;

    /// <summary>
    /// Raised when damage is taken.
    /// </summary>
    public event EventHandler Damaged;

    private float lastDamageTime;

    /// <summary>
    /// Takes the specified damage.
    /// </summary>
    /// <param name="damage">The amount of damage.</param>
    public void TakeDamage(int damage)
    {
        if (Time.time - lastDamageTime > DamageCooldown)
        {
            lastDamageTime = Time.time;
            this.Health -= damage;
            this.OnDamaged();
        }
        
        if (this.Health <= 0 && !this.IsDead)
        {
            this.IsDead = true;
            this.OnDeath();
        }
    }

    private void OnDamaged()
    {
        this.Damaged?.Invoke(this, EventArgs.Empty);
    }

    private void OnDeath()
    {
        this.Death?.Invoke(this, EventArgs.Empty);
    }
}
