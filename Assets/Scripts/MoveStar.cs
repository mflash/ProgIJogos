using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStar : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpSpeed = 5f;
    private Rigidbody2D rb;
    private Collider2D starColl;
    private float deltaX;
    private bool canJump;
    private LayerMask lm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        starColl = GetComponent<Collider2D>();
        deltaX = 0;
        canJump = false;
        lm = LayerMask.GetMask("Ground");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Colisão: " + col.gameObject.name);
        print("Minha posição: " + transform.position);
        print("Contatos: " + col.contactCount);
        foreach (var contato in col.contacts)
        {
            print("->" + contato.point);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        List<ContactPoint2D> contatos = new List<ContactPoint2D>();
        print("Trigger: " + col.name);
        print("Minha posição: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        deltaX = Input.GetAxis("Horizontal") * walkSpeed;
        if (Input.GetButton("Jump"))
        {
            if (starColl.IsTouchingLayers(lm))
                canJump = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 vel = new Vector2(deltaX, rb.velocity.y);
        rb.velocity = vel;
        if (canJump)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            canJump = false;
        }
        // rb.AddForce(new Vector2(deltaX, 0));
    }
}
