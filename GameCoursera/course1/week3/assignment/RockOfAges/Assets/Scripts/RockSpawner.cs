using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;

    // saved for efficiency
    [SerializeField]
    Sprite rockSprite0;
    [SerializeField]
    Sprite rockSprite1;
    [SerializeField]
    Sprite rockSprite2;

    public GameObject[] items;

    // spawn control
    const float SpawnDelay = 1;
    Timer spawnTimer;

    // spawn location support
    int SpawnX;
    int SpawnY;

    // Start is called before the first frame update
    void Start()
    {

        SpawnX = Screen.width / 2;
        SpawnY = Screen.height / 2;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnDelay;
        spawnTimer.Run();
        
    }

    // Update is called once per frame
    void Update()
    {
        items = GameObject.FindGameObjectsWithTag("rockObject");        
        if (spawnTimer.Finished)
        {
            spawnTimer.Run();
            if (items.Length < 3)
            {
                SpawnRock();
            }
        }
    }
    

    void SpawnRock()
    {
        // generate center location and create new rock
        Vector3 location = new Vector3(SpawnX, SpawnY,
                                       -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = worldLocation;

        // set random sprite for new rock
        SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = rockSprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = rockSprite1;
        }
        else
        {
            spriteRenderer.sprite = rockSprite2;
        }
    }
}
