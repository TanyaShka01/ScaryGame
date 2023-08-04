using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Room : MonoBehaviour
{
    public event Action<Room> OnSelected;
    public Button button;
    public Camera camera;
    protected virtual void Start()
    {
        button.onClick.AddListener(PrintClick);
    }

    void PrintClick()
    {
        OnSelected.Invoke(this);
    }

    public virtual void Activate()
    {
        camera.enabled = true;
    }

    public virtual void Disable()
    {
        camera.enabled = false;
    }
}
