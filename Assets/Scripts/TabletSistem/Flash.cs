using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Flash : MonoBehaviour
{
    public GameObject[] FlashingObjects;
    public float EnableTimeSec;
    public float DisableTimeSec;
    bool Play;

    void Start()
    {
        Play = true;
        MakeFlash();
    }

    async void MakeFlash()
    {
        while(Play == true)
        {
            int EnableTimeMS = (int)(1000 * EnableTimeSec);
            int DisableTimeMS = (int)(1000 * DisableTimeSec);
            await Task.Delay(EnableTimeMS);
            SetActiveObjects(false);
            await Task.Delay(DisableTimeMS);
            SetActiveObjects(true);
        }
    }
    // Вызывается при выходе из игры или уничтожении объекта
    void OnDestroy()
    {
        Play = false;
    }

    void SetActiveObjects(bool IsActive)
    {
        for (int i = 0; i < FlashingObjects.Length; i += 1)
        {
            FlashingObjects[i].SetActive(IsActive);
        }
    }
}
