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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeEnergy ()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (LightLeftOn == true)
            {
                energy -= 2;
            }
            if (LightRightOn == true)
            {
                energy -= 2;
            }
            if (LeftDoorSpend == true)
            {
                energy -= 2;
            }
            if (RightDoorSpend == true)
            {
                energy -= 2;
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
}