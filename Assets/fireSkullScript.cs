using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSkullScript : MonoBehaviour
{
    // Update is called once per frame
    public GameObject player, skull, Bullet;
    public float timer = 20;
    void Update()
    {
        if (timer <= 0)
        {
            helper.InstantiateFireBall(Bullet, player, skull.transform.position.x, skull.transform.position.y, 0, 0);
            timer = 200;
        } timer--;
        

    }

}
