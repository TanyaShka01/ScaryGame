using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animale
{
    public void Test()
    {
        Age = 5;
        
    }

    public override void MakeSound()
    {
        base.MakeSound();
        Debug.Log("My");
    } 
}
