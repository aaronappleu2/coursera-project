using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    // screen wrapping support
    float shipRadius;


    // Start is called before the first frame update
    void Start()
    {
        // saved for efficiency

        shipRadius = GetComponent<CircleCollider2D>().radius;
    }
    // Called when the game object becomes invisible to the camera
    void FixedUpdate()
    {
        wrapScreen();
    }
    void wrapScreen()
    {
        Vector3 position = transform.position;

        if (position.x - shipRadius > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }
        else if (position.x + shipRadius < ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        else if (position.y - 1.1 * shipRadius > ScreenUtils.ScreenTop)
        {
            position.y = -position.y;
        }
        else if (position.y + 1.1 * shipRadius < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        transform.position = position;
    }

}
