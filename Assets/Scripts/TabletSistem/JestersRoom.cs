using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JestersRoom : GlitchingRoom
{
    public GameObject EnergyButton;

    protected override void Start()
    {
        base.Start();
        EnergyButton.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        EnergyButton.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();
        EnergyButton.SetActive(false);
    }
}
