using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Invoker : MonoBehaviour
{
    Timer messageTimer;
    MessageEvent messageEvent;

    void Awake()
    {
        messageEvent = new MessageEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        messageTimer = gameObject.AddComponent<Timer>();
        messageTimer.Duration = 1;
        messageTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (messageTimer.Finished)
        {
            messageEvent.Invoke();
            messageTimer.Run();
        }
    }

    public void AddNoArgumentListener(UnityAction Listener)
    {
        messageEvent.AddListener(Listener);
    }
}
