using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text time;

    float elapsedSeconds = 0;
    bool isRuning = true;

    // Start is called before the first frame update
    void Start()
    {
        time.text = elapsedSeconds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRuning)
        {
            elapsedSeconds += Time.deltaTime;
            time.text = ((int)elapsedSeconds).ToString();
        }
    }

    public void StopGameTimer()
    {
        isRuning = false;
    }
}
