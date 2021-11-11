using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   private Vector3 moveDelta;
    private bool isJumping, movingRight, movingLeft, idle;
    private Animator anim;
    private SpriteRenderer _renderer;
    public float playerHealth = 100f;
    public GameObject player;
    Rigidbody2D playerRigid;
    void Start()
    {   anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {   float x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical"), xVelocity, yVelocity;
        movingLeft = helper.PlayerBoolSwitcher("left",x,y);
        movingRight = helper.PlayerBoolSwitcher("right",x,y);
        if (movingLeft == true)
        _renderer.flipX = true;
        else if (movingRight == true)
        _renderer.flipX = false;
        isJumping = helper.PlayerBoolSwitcher("jump",x,y);
        idle = helper.PlayerBoolSwitcher("idle",x,y);
        xVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'x');
        yVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'y');
        helper.MoveEntity(xVelocity,yVelocity, playerRigid);
    }
    void Update()
    {
        print(playerHealth);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            playerHealth--;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth--;
        }
    }
}