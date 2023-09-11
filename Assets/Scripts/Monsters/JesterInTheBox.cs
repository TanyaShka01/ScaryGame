using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class JesterInTheBox : Monster
{
    public GameObject CloseChest;
    public GameObject OpenChest;
    public Image Gear;
    public Animator[] Animators;
    public Transform InTheBox1;
    public Transform InTheBox2;
    float EnergyLevel = 1;
    bool IsCharging;
    bool IsOpen;
    public Transform[] SideJesters;
    // Start is called before the first frame update
    void Start()
    {
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void Play()
    {
        sleep = false;
        while(sleep == false)
        {
            await Task.Delay(1000);
            if (sleep == true)
            {
                return;
            }
            if (IsCharging == true)
            {
                EnergyLevel += 0.1f;
                if (EnergyLevel > 1)
                {
                    EnergyLevel = 1;
                }
            }
            else
            {
                EnergyLevel -= 0.07f;
            }
            Gear.fillAmount = EnergyLevel;
            if (EnergyLevel < 0.5f && IsOpen == false)
            {
                IsOpen = true;
                transform.position = InTheBox2.position;
                CloseChest.SetActive(false);
                OpenChest.SetActive(true);
                WaitAndLaught();
            }
            if (EnergyLevel >= 0.5f && IsOpen == true)
            {
                IsOpen = false;
                transform.position = InTheBox1.position;
                CloseChest.SetActive(true);
                OpenChest.SetActive(false);
            }
            if (EnergyLevel <= 0)
            {
                int n = 0;
                SoundControler.Instance.PlayMusicBox(true);
                await Task.Delay(5000);
                while (n != 3)
                {
                    if (n == 0)
                    {
                        Animators[n].SetTrigger("Attack");
                        n += 1;
                    }
                    if (n == 1)
                    {
                        SideJesters[0].localPosition = new Vector3(-0.062f, 0, -1.036f);
                        SideJesters[0].localEulerAngles = new Vector3(0, 39.006f, 0);
                        Animators[n].SetTrigger("Attack");
                        n += 1;
                    }
                    if (n == 2)
                    {
                        SideJesters[1].localPosition = new Vector3(0.22f, 0.035f, 0.995f);
                        SideJesters[1].localEulerAngles = new Vector3(0, -45.978f, 0);
                        Animators[n].SetTrigger("Attack");
                        n += 1;
                    }
                }
                SoundControler.Instance.PlayMusicBox(false);
                Lose();
                return;
            }
        }
    }

    public void StartCharge()
    {
        Debug.Log("Charge");
        IsCharging = true;
    }

    public void EndCharge()
    {
        Debug.Log("End");
        IsCharging = false;
    }

    async void WaitAndLaught()
    {
        int LaughtDelay = Random.Range(2, 5);
        await Task.Delay(LaughtDelay * 1000);
        if(EnergyLevel > 0 && EnergyLevel < 0.5f)
        {
            SoundControler.Instance.PlayJesterLaught(true);
            Debug.Log("JesterLaught");
        }
    }

    protected override void PlayScreemSound()
    {
        SoundControler.Instance.PlayJesterScream(true);
    }
}
