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

        

        StartMoving(angle);

        transform.position = location;
    }

    void StartMoving(float angle)
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
        const float MinImpulseForce = 0.5f;
        const float MaxImpulseForce = 1.5f;

        Vector2 moveDirection = new Vector2(
           Mathf.Cos(angle * Mathf.Deg2Rad),
           Mathf.Sin(angle * Mathf.Deg2Rad));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GetComponent<Rigidbody2D>().AddForce(
           moveDirection * magnitude,
           ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if(gameObject.transform.localScale.x >= 0.5)
            {
                divideAsteroid();
            }
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

    void divideAsteroid()
    {
        float angle = 0;
        gameObject.GetComponent<CircleCollider2D>().radius /= 2;

        Vector3 scale = gameObject.transform.localScale;
        scale.x /= 2;
        scale.y /= 2;
        transform.localScale = scale;

        GameObject[] smallAsteroids = new GameObject[2];
        for (int i = 0; i < smallAsteroids.Length; i++)
        {
            angle = Random.Range(0, 360);
            smallAsteroids[i] = Instantiate(gameObject);
            smallAsteroids[i].GetComponent<Asteroid>().StartMoving(angle);
        }
    }
}
