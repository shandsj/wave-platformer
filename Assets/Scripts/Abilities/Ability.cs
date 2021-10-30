using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ability : MonoBehaviour
{
    /// <summary>
    /// The prefab used for the ability.
    /// </summary>
    public GameObject Prefab;
    
    /// <summary>
    /// The amount of time to wait after using before an ammo is refilled.
    /// </summary>
    public float RefillTime;

    /// <summary>
    /// The maximum amount of ammo the player can carry.
    /// </summary>
    public int MaximumAmmoPouchSize = 3;

    /// <summary>
    /// The movement speed of the ability.
    /// </summary>
    public float MovementSpeed;

    /// <summary>
    /// The damage of the ability.
    /// </summary>
    public int Damage;

    private int ammoPouchSize;
    private float lastRefillTime;
    private List<GameObject> instances = new List<GameObject>();

    /// <summary>
    /// Used to determine if the sprite using the ability is facing left or right.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.ammoPouchSize = this.MaximumAmmoPouchSize;
    }

    public bool CanCast()
    {
        return this.ammoPouchSize > 0;
    }

    private void Update()
    {
        this.RefillIfNeeded();
    }

    public void Cast()
    {
        if (CanCast())
        {
            var instance = GameObject.Instantiate(Prefab);
            instance.transform.position = transform.position;
            instance.transform.Rotate(0, 0, spriteRenderer.flipX ? 180 : 0);

            var abilityInstanceController = instance.GetComponent<AbilityInstanceController>();
            abilityInstanceController.Direction = new Vector3(spriteRenderer.flipX ? -1 : 1, 0, 0);
            abilityInstanceController.Damage = this.Damage;
            abilityInstanceController.Speed = this.MovementSpeed;
            instances.Add(instance);

            // Start the refill timer if they just used their first ammo.
            if (this.ammoPouchSize == this.MaximumAmmoPouchSize)
            {
                this.lastRefillTime = Time.time;
            }
            this.ammoPouchSize--;
        }
    }

    private void RefillIfNeeded()
    {
        if (Time.time - this.lastRefillTime > RefillTime)
        {
            if (this.ammoPouchSize < this.MaximumAmmoPouchSize)
            {
                this.ammoPouchSize++;
                this.lastRefillTime = Time.time;
            }
        }
    }
}
