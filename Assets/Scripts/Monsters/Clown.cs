using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Clown : Monster
{
    public GameObject PointDoor;
    public GameObject CorridorPoint;
    public GameObject EndCorridorPoint;
    public DoorSwitcher LeftDoor;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void Walk()
    {
        sleep = false;
        while(sleep == false)
        {
            await StandUp();
            if (sleep == true)
            {
                return;
            }
            await GoToDoor();
            if (sleep == true)
            {
                return;
            }
            await RunInCoridor();
            if (sleep == true)
            {
                return;
            }
            if (LeftDoor.IsOpen == true)
            {
                animator.SetTrigger("Screem");
                Lose();
            }
            else
            {
                transform.position = StartPosition;
            }
        }

    
    }
    async Task StandUp()
    {
        int Waiting = Random.Range(2, 3);
        await Task.Delay(1000 * Waiting);
        if (sleep == true)
        {
            return;
        }
        animator.SetTrigger("WakeUp");
        await Task.Delay(8000);
        if (sleep == true)
        {
            return;
        }
    }
    async Task GoToDoor()
    {
        transform.LookAt(PointDoor.transform);
        animator.SetTrigger("Walk");
        while (Vector3.Distance(transform.position, PointDoor.transform.position) > 0.1f)
        {
            transform.position += transform.forward * 0.02f;
            await Task.Delay(20);
            if (sleep == true)
            {
                return;
            }
        }
        transform.position = PointDoor.transform.position;
        animator.SetTrigger("idle");
        int Waiting = Random.Range(2, 3);
        await Task.Delay(1000 * Waiting);
        if (sleep == true)
        {
            return;
        }
    }
    async Task RunInCoridor()
    {
        transform.position = CorridorPoint.transform.position;
        transform.rotation = CorridorPoint.transform.rotation;
        transform.LookAt(EndCorridorPoint.transform);
        animator.SetTrigger("Run");
        while (Vector3.Distance(transform.position, EndCorridorPoint.transform.position) > 0.3f)
        {
            transform.position += transform.forward * 0.29f;
            await Task.Delay(20);
            if (sleep == true)
            {
                return;
            }
        }
    }

    public override void Sleep()
    {
        base.Sleep();
        animator.SetTrigger("Sleep");
    }

    protected override void PlayScreemSound()
    {
        soundControler.PlayClowScream(true);
    }
}
