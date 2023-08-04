using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Lamp;
    public GameObject Buttary;
    public Side State;
    public enum Side
    {
        Left,
        Right
    }

    public Buttary Energy;
    bool EnergyEnd;
    // Start is called before the first frame update
    void Start()
    {
        Energy.OnEnergyEnd += TirnOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnergyEnd == true)
        {
            return;
        }
        if (MainCamera.enabled == true && Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit Hit))
            {
                if (Hit.collider.gameObject == gameObject)
                {
                    if (Lamp.activeSelf == true)
                    {
                        Lamp.SetActive(false);
                        if (State == Side.Left)
                        {
                            Buttary.GetComponent<Buttary>().LightLeftOn = false;
                        }
                        else if (State == Side.Right)
                        {
                            Buttary.GetComponent<Buttary>().LightRightOn = false;
                        }
                    }
                    else
                    {
                        Lamp.SetActive(true);
                        if (State == Side.Left)
                        {
                            Buttary.GetComponent<Buttary>().LightLeftOn = true;
                        }
                        if (State == Side.Right)
                        {
                            Buttary.GetComponent<Buttary>().LightRightOn = true;
                        }
                    }
                }
            }
        }
    }

    void TirnOff()
    {
    
        Lamp.SetActive(false);
        EnergyEnd = true;
    }
}
