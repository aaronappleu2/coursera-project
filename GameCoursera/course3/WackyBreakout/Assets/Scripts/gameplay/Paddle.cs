using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// paddle control

public class Paddle : MonoBehaviour
{
    Rigidbody2D paddleRifidbody2D;
    float halfWidth;
    const float BounceAngleHalfRange = 60*Mathf.Deg2Rad;
    float halfColliderHeight;

    // Start is called before the first frame update
    void Start()
    {
        paddleRifidbody2D = GetComponent<Rigidbody2D>();
        halfWidth = GetComponent<BoxCollider2D>().size.x * 1/2;
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y * 1 / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            float moveAmount = ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            if(Input.GetAxis("Horizontal") < 0)
            {
                moveAmount *= -1;
            }
            paddleRifidbody2D.MovePosition(
                paddleRifidbody2D.position 
                + new Vector2(CalculateClampedX(moveAmount), 0));
        }        
    }

    float CalculateClampedX(float deltaX)
    {
        if (Mathf.Abs(transform.position.x + deltaX) > ScreenUtils.ScreenRight - halfWidth)
        {
            deltaX = 0;
        }
        return deltaX;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            
            if (HitOnTop(coll))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    halfWidth;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
        }
    }

    bool HitOnTop(Collision2D coll)
    {
            if (Mathf.Abs(coll.transform.position.y - transform.position.y) > halfColliderHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
}
