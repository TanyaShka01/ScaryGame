using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitcher : MonoBehaviour
{
    public bool IsOpen;
    public GameObject Door;
    public Camera MainCamera;
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
        IsOpen = true;
        Energy.OnEnergyEnd += MakeEnergyEnd;
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
                    if (IsOpen == true)
                    {
                        IsOpen = false;
                        if (State == Side.Left)
                        {
                            Buttary.GetComponent<Buttary>().LeftDoorSpend = true;
                            Door.transform.Rotate(Vector3.forward * 90);
                        }
                        else if (State == Side.Right)
                        {
                            Buttary.GetComponent<Buttary>().RightDoorSpend = true;
                            Door.transform.Rotate(Vector3.forward * -90f);
                        }
                    }
                    else
                    {
                       TirnOff();
                    }
                }
            }
        }
    }

    void TirnOff()
    {
        if (IsOpen == true)
        {
            return;
        }
        IsOpen = true;
        if (State == Side.Left)
        {
            Buttary.GetComponent<Buttary>().LeftDoorSpend = false;
            Door.transform.Rotate(Vector3.forward * -90f);
        }
        if (State == Side.Right)
        {
            Buttary.GetComponent<Buttary>().RightDoorSpend = false;
            Door.transform.Rotate(Vector3.forward * 90);
        }
    }

    void MakeEnergyEnd()
    {
        EnergyEnd = true;
        TirnOff();
    }
}
