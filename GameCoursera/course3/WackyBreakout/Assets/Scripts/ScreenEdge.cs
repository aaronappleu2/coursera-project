using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdge : MonoBehaviour
{
    List<Vector2> v2List = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        v2List.Add(new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom));
        v2List.Add(new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop));
        v2List.Add(new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop));
        v2List.Add(new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom));

        GetComponent<EdgeCollider2D>().points = v2List.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
