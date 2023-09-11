using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Buttary : MonoBehaviour
{
    int energy = 100;
    public bool LightLeftOn;
    public bool LightRightOn;
    public bool LeftDoorSpend;
    public bool RightDoorSpend;
    public bool TabletOn;
    public TMP_Text EnergyText;
    public Image EnergyImage;
    
    public event Action OnEnergyEnd;

    void Start()
    {
        StartCoroutine(ChangeEnergy());
    }

    IEnumerator ChangeEnergy ()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (LightLeftOn == true)
            {
                energy -= 3;
            }
            if (LightRightOn == true)
            {
                energy -= 3;
            }
            if (LeftDoorSpend == true)
            {
                energy -= 5;
            }
            if (RightDoorSpend == true)
            {
                energy -= 5;
            }
            EnergyText.text = energy.ToString();
            EnergyImage.fillAmount = energy/100f;

            if (energy <= 0)
            {
                OnEnergyEnd.Invoke();
                energy = 0;
                break;
            }
        }
    }

    public void Fill()
    {
        energy = 100;
    }
}