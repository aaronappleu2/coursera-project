using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control the ship
public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;
    [SerializeField]
    GameObject HUD;

    Rigidbody2D shipRigidbody2D;
    CircleCollider2D shipCircleCollider2D;

    float ThrustForce = 10;
    Vector2 thrustDirection = new Vector2(1, 0);
    float shipRadius;
    float RotateDegreesPerSecond = 180;


    // Start is called before the first frame update
    void Start()
    {

        shipRigidbody2D = GetComponent<Rigidbody2D>();
        shipCircleCollider2D = GetComponent<CircleCollider2D>();
        shipRadius = shipCircleCollider2D.radius;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Rotate") != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (Input.GetAxis("Rotate") < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
        }
        float newDirection = transform.eulerAngles.z * Mathf.Deg2Rad;
        thrustDirection = new Vector2(Mathf.Cos(newDirection), Mathf.Sin(newDirection));

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(prefabBullet) as GameObject;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }

    }

    // Calls to FixedUpdate
    void FixedUpdate()
    {
        wrapScreen();
        if (Input.GetAxis("Thrust") != 0)
        {
            shipRigidbody2D.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

    void wrapScreen()
    {
        Vector3 position = transform.position;

        if (position.x + shipRadius > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }
        else if (position.x - shipRadius < ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        else if (position.y + shipRadius > ScreenUtils.ScreenTop)
        {
            position.y = -position.y;
        }
        else if (position.y - shipRadius < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            HUD.GetComponent<HUD>().StopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
    }
}
