using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DYP.BasicMovementController2D))]
public class EnemyMovmentController : MonoBehaviour
{
    [SerializeField] public float JumpCooldown = 5f;
    [SerializeField] public GameObject Target;
    private DYP.BasicMovementController2D movementController2D;
    private float lastJumpTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        movementController2D = GetComponent<DYP.BasicMovementController2D>();
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
        
        movementController2D.InputMovement(new Vector2(.1f * direction, 0));

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
