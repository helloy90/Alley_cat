using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThrough : MonoBehaviour
{

    private Collider2D obj_collider;
    private bool player_on_platform;

    void Start()
    {
        obj_collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (player_on_platform && Input.GetAxisRaw("Vertical") < 0)
        {
            obj_collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        obj_collider.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<Cat>();
        if (player != null)
        {
            player_on_platform = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, false);
    }
}
