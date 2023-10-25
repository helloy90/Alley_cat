using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D cat_body;
    [SerializeField] private float jump_speed = 3.0f;
    [SerializeField] private float walk_speed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true) {
            cat_body.velocity = Vector2.up * jump_speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true) {
            cat_body.velocity = Vector2.left * walk_speed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true) {
            cat_body.velocity = Vector2.right * walk_speed;
        }
    }

    // void SetAnimationState() {
    //     if ()
    // }
}
