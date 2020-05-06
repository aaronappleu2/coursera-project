using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite greenrock;
    [SerializeField]
    Sprite whiterock;
    [SerializeField]
    Sprite magentarock;

    public void Initialize(Direction direction, Vector3 location)
    {
        //randomly pick one of the three asteroid sprites for the asteroid
        SpriteRenderer asteroid = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            asteroid.sprite = greenrock;
        }
        else if (spriteNumber == 1)
        {
            asteroid.sprite = whiterock;
        }
        else
        {
            asteroid.sprite = magentarock;
        }

        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float rand = 15;
        float angle = 0;


        switch (direction)
        {
            case Direction.Up:
                angle = Random.Range(90-rand,90+rand);
                break;
            case Direction.Down:
                angle = Random.Range(-90 - rand, -90 + rand);
                break;
            case Direction.Left:
                angle = Random.Range(180 - rand, 180 + rand);
                break;
            case Direction.Right:
                angle = Random.Range( - rand, rand);
                break;
        }

        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
        transform.position = location;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

}
