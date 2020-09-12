using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoker invoker = Camera.main.GetComponent<Invoker>();
        invoker.AddNoArgumentListener(PrintMessage);
    }

    // Update is called once per frame

    void PrintMessage()
    {
        print("lalala");
    }
}
