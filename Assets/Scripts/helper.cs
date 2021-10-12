using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class helper : MonoBehaviour
{
    public static void MoveEntity(float xVelocity, float yVelocity, Rigidbody2D entityRigid)
    {
        entityRigid.AddForce(new Vector2(xVelocity,yVelocity), ForceMode2D.Force);
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
            velocity = 20f;
            if (jumping == false)
            velocity = 0f;
            break;
        } return velocity;
    }
}
