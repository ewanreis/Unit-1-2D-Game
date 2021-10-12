using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector3 moveDelta;
    private bool isJumping, movingRight, movingLeft, idle;
    private Animator anim;
    public GameObject player;
    Rigidbody2D playerRigid;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"),y=Input.GetAxisRaw("Vertical"), xVelocity, yVelocity;
        moveDelta = new Vector3(x, y, 0);
        // Check if player is pressing jump
        if (y > 0)
           isJumping = true;
        else if(y <= 0)
           isJumping = false;
        // Check if player is moving
        if (x > 0)
        {   movingRight = true;
            movingLeft = false;
            idle = false;
        } else if (x < 0)
        {   movingLeft = true;
            movingRight = false;
            idle = false;
        } else if (x == 0)
        {   idle = true;
            movingRight = false;
            movingLeft = false;
        }
        xVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'x');
        yVelocity = helper.PlayerMovementRestraints(isJumping,idle,movingLeft,movingRight,'y');
        helper.MoveEntity(xVelocity,yVelocity, playerRigid);
    }
}
