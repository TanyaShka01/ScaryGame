using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class Tablet : MonoBehaviour
{
    bool IsOpen;
    public Animator Anim;
    public Camera MainCamera;
    public Room[] Rooms;
    public GameObject Buttons;
    public SoundControler soundControler;
    public Animator NoiseAnimator;
    public GameObject Frame;
    public bool Block;
    // Start is called before the first frame update
    void Start()
    {
        Buttons.SetActive(false);
        for(int i = 0; i < Rooms.Length; i += 1)
        {
            Rooms[i].OnSelected += SelectRoom;
        }
        Frame.SetActive(false);
        PlayNoiseAnim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectRoom(Room SelectedRoom)
    {
        MainCamera.enabled = false;
        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].Disable();
        }
        soundControler.PlayButtonClick(true);
        SelectedRoom.Activate();
    }

    public void Switch()
    {
        if (Block == true)
        {
            return;
        }
        IsOpen = !IsOpen;
        if (IsOpen == true)
        {
            StartCoroutine(ActiwateRoomCamera());
        }
        else
        {
           StartCoroutine(ActiwateMainCamera());
        }
    }

    IEnumerator ActiwateRoomCamera()
    {
        Block = true;
        Anim.SetTrigger("Open");
        yield return new WaitForSeconds(1.2f);
        MainCamera.enabled = false;
        Rooms[0].Activate();
        Block = false;
        Buttons.SetActive(true);
        Frame.SetActive(true);
        //NoiseAnimator.SetTrigger("PlayNoise");
    }

    IEnumerator ActiwateMainCamera()
    {
        Buttons.SetActive(false);
        Block = true;
        Anim.SetTrigger("Close");
         for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].Disable();
        }
        MainCamera.enabled = true;
        yield return new WaitForSeconds(1.2f);
        Block = false;
        //NoiseAnimator.SetTrigger("PauseNoise");
        Frame.SetActive(false);
    }

    public void ShowMainRoom()
    {
         for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].Disable();
        }
        Buttons.SetActive(false);
        MainCamera.GetComponent<Camera>().enabled = true;
        Anim.SetTrigger("FastOpen");
    }

    async void PlayNoiseAnim()
    {
        while(true)
        {
            int a = UnityEngine.Random.Range(7, 10);
            await Task.Delay(a * 1000);
            NoiseAnimator.SetTrigger("PlayNoise");
        }
    }
}