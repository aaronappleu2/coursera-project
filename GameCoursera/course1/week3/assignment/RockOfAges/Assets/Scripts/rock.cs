using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class rock : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 2f;
        const float MaxImpulseForce = 4f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        speed = Random.Range(2,6);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward*speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
