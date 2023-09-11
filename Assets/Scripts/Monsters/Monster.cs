using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Monster : MonoBehaviour
{
    public GameObject ScreemPoint;
    public Tablet tablet;
    public LoseManu GameOver;
    public Animator animator;
    protected bool sleep;
    protected Vector3 StartPosition;
    
    public virtual void Sleep()
    {
        sleep = true;
        transform.position = StartPosition;
    }

    void OnDestroy()
    {
        Sleep();
    }

    protected async void Lose()
    {
        transform.position = ScreemPoint.transform.position;
        transform.rotation = ScreemPoint.transform.rotation;
        tablet.ShowMainRoom();
        PlayScreemSound();
        await Task.Delay(3000);
        if (sleep == true)
            {
                return;
            }
        GameOver.Over();
    }

    protected virtual void PlayScreemSound()
    {

    }
}
