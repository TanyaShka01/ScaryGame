using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimerEnd += ShowWindow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowWindow(int time)
    {
        Debug.Log("Show" + time);
    }
}
