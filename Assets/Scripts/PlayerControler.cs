using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 move;
    public Vector2 aim;
    public float moveSpeedMultipler;
    public Animator anim;
    public bool shootButton;
    public bool jumpButton;
    public float jumpMultipler;
    

    public bool IsGrounded;
    public Collider2D groundDetectionColl;
    public Collider2D groundColl;
    public Collider2D defColl;
    public bool isMoving;


public void Awake()
    {
        
        GameManager.instance.controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        GameManager.instance.controls.Player.Movement.canceled += ctx => move = Vector2.zero;
        GameManager.instance.controls.Player.Jump.started += ctx => jumpButton = true;
        GameManager.instance.controls.Player.Jump.canceled += ctx => jumpButton = false;
        GameManager.instance.controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        GameManager.instance.controls.Player.Aim.canceled += ctx => move = Vector2.zero;
        GameManager.instance.controls.Player.Shoot.started += ctx => shootButton = true;
        GameManager.instance.controls.Player.Shoot.canceled += ctx => shootButton = false;


    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.otherCollider == groundDetectionColl)
        {
            if (collision.collider.tag == "GroundColl")
            {
                IsGrounded = true;
            }
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider == groundDetectionColl)
        {
            if (collision.collider.tag == "GroundColl")
            {
                IsGrounded = false;
            }
        }

    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == groundColl)
        {
            IsGrounded = true;
            anim.SetBool("isGrounded", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == groundColl)
        {
            IsGrounded = false;
            anim.SetBool("isGrounded", false);

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveAndAnimate();
        
    }
    void Fire()
    {

    }
    void UpdateMoveAndAnimate()
    {
        anim.SetFloat("move-x", move.x);
        Debug.Log("isGrounded: "+IsGrounded);
        Debug.Log("jump :"+jumpButton);
        move = move.normalized;
        /*if (false)
        {
            if (move.magnitude != 0)
                rb.velocity = move * moveSpeedMultipler; // JETPACK
        }*/
        if (jumpButton == true && IsGrounded == true)
        {
            rb.velocity = new(rb.velocity.x, rb.velocity.y + jumpMultipler);
        }
        Debug.Log(move.magnitude);
        if (move.magnitude != 0)
        {
            anim.SetBool("isMoving", true);
            rb.velocity = new(move.x * moveSpeedMultipler, rb.velocity.y);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (jumpButton == true)
        {
            jumpButton = false;
        }
    }
}
