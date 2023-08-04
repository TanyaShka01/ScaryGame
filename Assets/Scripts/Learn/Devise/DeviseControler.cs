using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviseControler : MonoBehaviour
{
    public Devise[] Devises;
    void Start()
    {
        for(int i = 0; i < Devises.Length; i += 1)
        {
            Devises[i].OnBroke += ChekDevise;
        }
    }

    void Update()
    {
        
    }

    void ChekDevise(Devise BrokeDevice)
    {
        BrokeDevice.Repair();
        Debug.Log(BrokeDevice.name + "починен");
    }
}
