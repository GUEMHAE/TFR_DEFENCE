using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SynergyInfoUI : MonoBehaviour
{
    public GameObject LightSynergy;
    public GameObject DarkSynergy;
    public GameObject WaterSynergy;
    public GameObject FireSynergy;
    public GameObject GroundSynergy;
    public GameObject AirSynergy;

    public void LightSynergyInfo()
    {
        LightSynergy.SetActive(true);
    }

    public void DarkSynergyInfo()
    {
        DarkSynergy.SetActive(true);
    }

    public void WaterSynergyInfo()
    {
        WaterSynergy.SetActive(true);
    }

    public void FireSynergyInfo()
    {
        FireSynergy.SetActive(true);
    }

    public void GroundSynergyInfo()
    {
        GroundSynergy.SetActive(true);
    }

    public void AirSynergyInfo()
    {
        AirSynergy.SetActive(true);
    }


    public void CloseLightSynergyInfo()
    {
        LightSynergy.SetActive(false);
    }

    public void CloseDarkSynergyInfo()
    {
        DarkSynergy.SetActive(false);
    }

    public void CloseWaterSynergyInfo()
    {
        WaterSynergy.SetActive(false);
    }

    public void CloseFireSynergyInfo()
    {
        FireSynergy.SetActive(false);
    }

    public void CloseGroundSynergyInfo()
    {
        GroundSynergy.SetActive(false);
    }

    public void CloseAirSynergyInfo()
    {
        AirSynergy.SetActive(false);
    }

}
