using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class helper : MonoBehaviour
{
    public static void MoveEntity(float xVelocity, float yVelocity, Rigidbody2D entityRigid)
    {   if (entityRigid.velocity.x > -10f && entityRigid.velocity.x < 10f)
            entityRigid.AddForce(new Vector2(xVelocity,0), ForceMode2D.Force);
        if (entityRigid.velocity.y >= 0f && entityRigid.velocity.y < 1f)
            entityRigid.AddForce(new Vector2(0, yVelocity), ForceMode2D.Impulse);
    }
    public static float PlayerMovementRestraints(bool jumping, bool isIdle, bool left, bool right, char mode)
    {   float velocity=0;
        switch (mode)
        {   case 'x':
        if (left == true && right == false)
        velocity = -10f;
        if (right == true && left == false)
        velocity = 10f;
        if (right == false && left == false && isIdle == true)
        velocity = 0f;
            break;
            case 'y':
            if (jumping == true)
            velocity = 1f;
            if (jumping == false)
            velocity = 0f;
            break;
        } return velocity;
    }
}
