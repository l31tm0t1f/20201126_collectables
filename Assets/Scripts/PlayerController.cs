using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public List<string> inventory;

    // Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    // FSM
    private enum State {Idle, Run, Jump, Fall, Hurt}
    private State state = State.Idle;
    // Inspector variables
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    // [SerializeField] private float hurtForce = 10f;
    private int summa = 0;
    private int value;


    private void Start()
    {
        inventory = new List<string>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(state != State.Hurt)   
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumerator state
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        // Moving Left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        // Moving Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        // Jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers())
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.Jump;
    }
    private void AnimationState()
    {
        if (state == State.Jump)
        {
         if (rb.velocity.y < 0.1f)
            {
                state = State.Fall;
            }
        }
        else if (state == State.Fall)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.Idle;
            }
        else if (state == State.Hurt)
            {
                if(Mathf.Abs(rb.velocity.x) < .1f)
                {
                    state = State.Idle;
                }
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 1.2f)
        {
            // Moving
            state = State.Run;
        }
        else
        {
            state = State.Idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Collectable"))
        {
            print("COLLECTED!!!");
            string itemType = collision.gameObject.GetComponent<CollectScript>().itemType;
            print("We have collected a: " + itemType);
            int.TryParse(itemType, out value);

            summa = summa + value;
            print("Summa on " + summa);
            inventory.Add(itemType);
            print("Arve kokku: " + inventory.Count);
            Destroy(collision.gameObject);

        }
    }


}