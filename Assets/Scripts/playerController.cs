using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   private Vector3 moveDelta;
    private bool isJumping, movingRight, movingLeft, idle;
    private Animator anim;
    public GameObject player;
    Rigidbody2D playerRigid;
    void Start()
    {   anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {   float x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical"), xVelocity, yVelocity;
        movingLeft = helper.PlayerBoolSwitcher("left",x,y);
        movingRight = helper.PlayerBoolSwitcher("right",x,y);
        isJumping = helper.PlayerBoolSwitcher("jump",x,y);
        idle = helper.PlayerBoolSwitcher("idle",x,y);
        xVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'x');
        yVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'y');
        helper.MoveEntity(xVelocity,yVelocity, playerRigid);
    }
}