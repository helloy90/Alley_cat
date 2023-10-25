using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class HostileCat : MonoBehaviour
{
    private Rigidbody2D cat_body;
    private Animator animator;

    private LogicScript logic;

    [SerializeField] private float move_speed;
    private float move_horizontal;
    private float move_vertical;
    Vector3 local_scale;
    private bool facing_right;
    private float vector_x;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move_speed = 1.5f;
        local_scale = transform.localScale;
        facing_right = false;
        vector_x = 0;
    }

    void Update()
    {
        move_horizontal = Input.GetAxisRaw("Horizontal");
        move_vertical = Input.GetAxisRaw("Vertical");

        SetAnimationState();
        CheckFacing();
    }

    void FixedUpdate()
    {
        vector_x = move_horizontal * move_speed;

        cat_body.velocity = new Vector2(vector_x, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cat>() != null) {
            logic.Decrease();
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = new Vector3(3.326f, transform.position.y, transform.position.z);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }

    void SetAnimationState()
    {
        animator.SetBool("Walking", true);
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
