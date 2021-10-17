using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpellCaster : MonoBehaviour
{
    public GameObject SpellPrefab;
    public float Cooldown;
    public float AmmoPouchSize;

    public float Speed;

    private List<GameObject> instances = new List<GameObject>();
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Cast()
    {
        var instance = GameObject.Instantiate(SpellPrefab);
        instance.transform.position = transform.position;
        instance.transform.Rotate(0, 0, spriteRenderer.flipX ? 180 : 0);
        instance.GetComponent<VelocityController>().Direction = new Vector3(spriteRenderer.flipX ? -1 : 1, 0, 0);
        instances.Add(instance);
    }
}
