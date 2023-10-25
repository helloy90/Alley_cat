using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileCat : MonoBehaviour
{
    private Rigidbody2D cat_body;
    private Animator animator;

    private LogicScript logic;

    [SerializeField] private float move_speed;
    Vector3 local_scale;
    private bool facing_right;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move_speed = 1.5f;
        local_scale = transform.localScale;
        facing_right = false;
    }

    void Update()
    {
        cat_body.velocity = new Vector2(-move_speed, 0);
        CheckFacing();

        if (transform.position.x < -3.51f) {
            Reset();
        }
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void Reset()
    {
        transform.position = new Vector3(3.51f, transform.position.y, transform.position.z);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }

    void CheckFacing()
    {

        if ((facing_right && local_scale.x < 0) || (!facing_right && local_scale.x > 0))
        {
            local_scale.x *= -1;
        }

        transform.localScale = local_scale;
    }
}
