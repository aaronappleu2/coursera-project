using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Timer liveTimer;
    const float deathTime = 1.5f;

    public void ApplyForce(Vector2 direction)
    {
        float magnitude = 15.0f;
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        liveTimer = gameObject.AddComponent<Timer>();
        liveTimer.Duration = deathTime;
        liveTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(liveTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
