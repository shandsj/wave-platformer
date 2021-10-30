using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(SpriteFlashEffect))]
public class PlayerController : MonoBehaviour
{
    private HealthController healthController;
    private SpriteFlashEffect spriteFlashEffect;

    // Start is called before the first frame update
    private void Start()
    {
        this.healthController = GetComponent<HealthController>();
        this.spriteFlashEffect = GetComponent<SpriteFlashEffect>();

        this.healthController.Damaged += this.OnDamaged;
    }

    private void OnDamaged(object sender, EventArgs e)
    {
        this.spriteFlashEffect.Flash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.healthController.TakeDamage(1);
        }
    }
}
