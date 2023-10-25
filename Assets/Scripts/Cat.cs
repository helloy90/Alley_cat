using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public LogicScript logic;
    private Rigidbody2D cat_body;
    private Animator animator;

    [SerializeField] private float jump_force;
    [SerializeField] private float move_speed;
    private float move_horizontal;
    private float move_vertical;

    Vector3 local_scale;
    private bool facing_right;
    private float vector_x;

    private bool condition_met;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jump_force = 4.1f;
        move_speed = 1.5f;
        local_scale = transform.localScale;
        facing_right = true;
        vector_x = 0;
        condition_met = false;
    }

    void Update()
    {
        move_horizontal = Input.GetAxisRaw("Horizontal");
        move_vertical = Input.GetAxisRaw("Vertical");


        if (!condition_met)
        {
            SetAnimationState();
            CheckFacing();
        } else {
            animator.SetBool("Walking", false);
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
            cat_body.simulated = false;
        }
    }

    void FixedUpdate()
    {
        if (!condition_met)
        {
            vector_x = move_horizontal * move_speed;
        }

        if (move_vertical > 0.2f && cat_body.velocity.y == 0 && !condition_met)
        {
            cat_body.AddForce(new Vector2(0f, move_vertical * jump_force), ForceMode2D.Impulse);
        }
        if (!condition_met)
        {
            cat_body.velocity = new Vector2(vector_x, cat_body.velocity.y);
        }
        else
        {
            cat_body.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            condition_met = true;
            logic.Win();
        }
        if (collision.gameObject.CompareTag("Hostile")) {
            condition_met = true;
            logic.GameOver();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

    }

    void SetAnimationState()
    {
        if (Mathf.Abs(vector_x) == move_speed && cat_body.velocity.y == 0)
        {
            animator.SetBool("Walking", true);
        }
        if (vector_x == 0)
        {
            animator.SetBool("Walking", false);
        }
        if (cat_body.velocity.y > 0)
        {
            animator.SetBool("Jumping", true);
        }
        if (cat_body.velocity.y == 0)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
        }
        if (cat_body.velocity.y < 0)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }
    }

    void CheckFacing()
    {
        if (move_horizontal > 0.2f)
        {
            facing_right = true;
        }
        else if (move_horizontal < -0.2f)
        {
            facing_right = false;
        }

        if ((facing_right && local_scale.x < 0) || (!facing_right && local_scale.x > 0))
        {
            local_scale.x *= -1;
        }

        transform.localScale = local_scale;
    }
}
