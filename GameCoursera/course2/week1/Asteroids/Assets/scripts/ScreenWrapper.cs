using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    // screen wrapping support
    float Radius;


    // Start is called before the first frame update
    void Start()
    {
        // saved for efficiency
        if(gameObject.tag =="Asteroid")
        {
            Radius = GetComponent<CircleCollider2D>().radius;
        }
        else if(gameObject.tag == "Bullet")
        {
            Radius = GetComponent<BoxCollider2D>().size.x;
        }
        else
        {
            Radius = GetComponent<CircleCollider2D>().radius;
        }
    }
    // Called when the game object becomes invisible to the camera
    void FixedUpdate()
    {
        wrapScreen();
    }
    void wrapScreen()
    {
        Vector3 position = transform.position;

        if (position.x - Radius > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }
        else if (position.x + Radius < ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        else if (position.y - 1.1 * Radius > ScreenUtils.ScreenTop)
        {
            position.y = -position.y;
        }
        else if (position.y + 1.1 * Radius < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        transform.position = position;
    }

}
