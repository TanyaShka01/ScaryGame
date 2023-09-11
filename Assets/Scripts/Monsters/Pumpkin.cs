using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Pumpkin : Monster
{
    public GameObject[] Route1;
    public GameObject window;
    public DoorSwitcher RightDoor;
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
            animator.SetTrigger("Stand");
            int StartWaiting = Random.Range(7, 12);
            await Task.Delay(1000 * StartWaiting);
            if (sleep == true)
            {
                return;
            }
            for (int i = 0; i < 2; i += 1)
            {
                int Waiting = Random.Range(7, 12);
                animator.SetTrigger("Standing");
                transform.position = Route1[i].transform.position;
                transform.rotation = Route1[i].transform.rotation;
                await Task.Delay(1000 * Waiting);
                if (sleep == true)
                {
                    return;
                }
            }
            animator.SetTrigger("Window");
            transform.position = window.transform.position;
            transform.rotation = window.transform.rotation;
            await Task.Delay(5000);
            if (sleep == true)
            {
                return;
            }
            if (RightDoor.IsOpen == true)
            {
                animator.SetTrigger("Scream");
                
                Lose();
            }
            else
            {
                transform.position = StartPosition;
            }
        }
    }

    protected override void PlayScreemSound()
    {
        SoundControler.Instance.PlayPumpkinScream(true);
    }
}
