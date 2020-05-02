using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabAsteroid;

    // spawn control

    // spawn location support


    // Start is called before the first frame update
    void Start()
    {
        spawner(Direction.Up);
        spawner(Direction.Down);
        spawner(Direction.Left);
        spawner(Direction.Right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawner(Direction direction)
    {
        GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
        float AsteroidRadius = asteroid.GetComponent<CircleCollider2D>().radius;
        float location_x = 0;
        float location_y = 0;
        switch (direction)
        {
            case Direction.Up:
                location_y = ScreenUtils.ScreenBottom - AsteroidRadius;
                break;
            case Direction.Down:
                location_y = ScreenUtils.ScreenTop + AsteroidRadius;
                break;
            case Direction.Left:
                location_x = ScreenUtils.ScreenRight + AsteroidRadius;
                break;
            case Direction.Right:
                location_x = ScreenUtils.ScreenLeft - AsteroidRadius;
                break;
        }
        Vector3 location = new Vector3(location_x, location_y, 0);
        asteroid.GetComponent<Asteroid>().Initialize(direction, location);
    }
}
