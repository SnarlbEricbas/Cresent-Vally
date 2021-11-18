using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    BoxCollider2D col;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>(); //get game colliders
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            rb.velocity = new Vector2(3f, 0f); //left
        }
        else
        {
            rb.velocity = new Vector2(-3f, 0f); //right
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x), 1f); //no idea
    }
}
