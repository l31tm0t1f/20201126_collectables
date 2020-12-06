using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public List<string> inventory;                      

    // Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    // FSM
    private enum State {Idle, Run, Jump, Fall, Hurt}    // Character sprite animations
    private State state = State.Idle;                   // default animation is Idle
    // Inspector variables
    [SerializeField] private LayerMask Ground;          // Ground layer, to define jump donw anim
    [SerializeField] private float speed = 5f;          // character moving speed
    [SerializeField] private float jumpForce = 10f;     // character jump force
    private int ScoreCollected = 0;                     // value of collected coins
    private int value;                                  // ???
    public GameObject ThePanel_Win;                     // Win/Lost panels for showing Restart Menu
    public GameObject ThePanel_Lost;

    private void Start()
    {
        inventory = new List<string>();                 // creates the inventory list
        ThePanel_Win.SetActive(false);                  // Win/Lost panels are deactivated
        ThePanel_Lost.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(state != State.Hurt)                         // in any state other than Hurt
        {
            Movement();                                 // runs Movement function
        }
        AnimationState();                               // 
        anim.SetInteger("state", (int)state);           //sets animation based on Enumerator state
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal"); // Unity-specific input managing
        if (hDirection < 0)                             // Moving Left
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);   //rigidbody moves to "negative" direction
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)                                // Moving Right
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);    //rigidbody moves to "positive" direction
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers())     // Jump, only when is touching Ground layer
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // jumps according to jumpForce (jump height)
        state = State.Jump;                                   // used for assigning Jump animation
    }
    private void AnimationState()                             // animation states as declared at line 16
    {
        if (state == State.Jump)                              // when state is Jump
        {
         if (rb.velocity.y < 0.1f)                            // when character reaches highest point...
            {
                state = State.Fall;                           // ... the state is Fall (animation)
            }
        }
        else if (state == State.Fall)                         // when character is falling...
        {
            if (coll.IsTouchingLayers(Ground))                // ... then checks if touching Ground layer, if so, then anim state is Idle again
            {
                state = State.Idle;
            }
        else if (state == State.Hurt)                         // if anim state is Hurt
            {
                if(Mathf.Abs(rb.velocity.x) < .1f)            // checks when x-directional speed decreases almost 0, then anim state is idle again
                {
                    state = State.Idle;
                }
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 1.2f)           // when speed is over certain value
        {
            state = State.Run;                              // anim state is Moving
        }
        else
        {
            state = State.Idle;                             // in all other cases anim state is Idle
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)     // when triggering woith other objects
    {

        if(collision.CompareTag("Collectable"))             // if this object has a certain tag
        {
            // print("COLLECTED!!!");                       // prints "Collected"
            string itemType = collision.gameObject.GetComponent<CollectScript>().itemType;  // string itemType gets value from collected object which has the attribute itemType (itemType is the value of the coin)
            // print("We have collected a: " + itemType);   // prints out the value of the collected coin
            int.TryParse(itemType, out value);              // converts the string to int, "itemType" becomes "value"

            ScoreCollected = ScoreCollected + value;        // Adds coin value to the ScoreCollected value
            //print("Summa on " + ScoreCollected);          // prints out the value of collected coins
            inventory.Add(itemType);                        // inventory list will have one more element - collected coin value (itemType)
            // print("Arve kokku: " + inventory.Count);     // prints out how many coin values there are in the list
            Destroy(collision.gameObject);                  // destroyes the collected coin object
            if (ScoreCollected == ScoreScript.SummaScore)   // when the sum of collected coin values equals to the ScoreScript.SummaScore
            {
                ThePanel_Win.SetActive(true);               // the panel (which consist congrats-text and buttons: Next Level and Main Menu
                Time.timeScale = 0;                         // Will stop the game

            }
            else if (ScoreCollected >= ScoreScript.SummaScore) // when the sum of collected coin values is bigger than the ScoreScript.SummaScore
            {
                ThePanel_Lost.SetActive(true);              // the panel (which consist "try again"-text and buttons: Try Again and Main Menu
                Time.timeScale = 0;                         // Will stop the game
            }
        }
    }


}