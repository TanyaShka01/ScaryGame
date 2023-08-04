using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalesController : MonoBehaviour
{
    void Start()
    {
        Animale jarry = new Animale();
        Cat Tom = new Cat(); 
        Animale Guffi = new Dog(); 

        jarry.MakeSound();
        Tom.MakeSound();
        Guffi.MakeSound(); 

        jarry.Age = 6;
        Guffi.Age = 4;
        Tom.Age = 5;
    }
}
