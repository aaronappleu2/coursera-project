using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using Vector2 = UnityEngine.Vector2;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballrigidbody2D;
    float angle = -90;

    // Start is called before the first frame update
    void Start()
    {
        ballrigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 thrustDirection = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad), 
            Mathf.Sin(angle * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().AddForce(thrustDirection * ConfigurationUtils.BallImpulseForce);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDirection(Vector2 direction)
    {
        float currentSpeed = ballrigidbody2D.velocity.magnitude;
        ballrigidbody2D.velocity = direction * currentSpeed;
    }
}
