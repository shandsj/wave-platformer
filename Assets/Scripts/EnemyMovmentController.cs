using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DYP.BasicMovementController2D))]
public class EnemyMovmentController : MonoBehaviour
{
    [SerializeField] public float JumpCooldown = 5f;
    [SerializeField] public GameObject Target;
    public float MinimumSpeed = .05f;
    public float MaximumSpeed = .15f;
    private DYP.BasicMovementController2D movementController2D;
    private float lastJumpTime = 0;
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        this.movementController2D = GetComponent<DYP.BasicMovementController2D>();
        this.speed = Random.Range(this.MinimumSpeed, this.MaximumSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        int direction = 0;
        if (Target.transform.position.x < transform.position.x)
        {
            direction = -1;
        }
        else if (Target.transform.position.x > transform.position.x)
        {
            direction = 1;
        }
        
        movementController2D.InputMovement(new Vector2(this.speed * direction, 0));

        if (ShouldJump())
        {
            lastJumpTime = Time.time;
            movementController2D.PressJump(true);
        }
    }

    private bool ShouldJump()
    {
        return movementController2D.IsAgainstWall() &&
            Target.transform.position.y > transform.position.y && 
            Time.time - lastJumpTime > JumpCooldown;
    }
}
