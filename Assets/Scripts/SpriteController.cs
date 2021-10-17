using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JumpState
{
    None,
    Jumping,
    Falling,
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DYP.BasicMovementController2D))]
public class SpriteController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private DYP.BasicMovementController2D movementController2D;
    private DYP.CharacterMotor2D characterMotor2D;
       

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();  
        movementController2D = GetComponent<DYP.BasicMovementController2D>();
        characterMotor2D = GetComponent<DYP.CharacterMotor2D>();

        movementController2D.OnFacingFlip += (direction) => spriteRenderer.flipX = direction != 1;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("ySpeed", characterMotor2D.Velocity.y);
        animator.SetFloat("xSpeed", Mathf.Abs(characterMotor2D.Velocity.x));
    }
}
