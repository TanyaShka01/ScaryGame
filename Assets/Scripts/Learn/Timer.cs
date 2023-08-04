using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Timer : MonoBehaviour
{
    public Action<int> OnTimerEnd;
    // Start is called before the first frame update
    void Start()
    {
        Time();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void Time()
    {
        int Wait = UnityEngine.Random.Range(5, 10);
        await Task.Delay(1000 * Wait);
        OnTimerEnd.Invoke(Wait);
    }
}
