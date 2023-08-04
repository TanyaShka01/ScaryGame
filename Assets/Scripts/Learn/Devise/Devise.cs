using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Devise : MonoBehaviour
{
    public event Action<Devise> OnBroke;
    private bool IsBroke = false;
    float time = 0;
    int NextBrakeTime;

    // Start is called before the first frame update
    void Start()
    {
        NextBrakeTime = UnityEngine.Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > NextBrakeTime && IsBroke == false)
        {
            IsBroke = true;
            OnBroke.Invoke(this);
            time = 0;
        }
    }

    public void Repair()
    {
        IsBroke = false;
    }
}
