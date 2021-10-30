using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstanceController : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;
    public int Damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthController>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
