using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCon : MonoBehaviour
{
    [SerializeField]
    private Light Spotlight;
    [SerializeField]
    private Light PointLight;
    [SerializeField]
    private Light Halo;
    [SerializeField]
    private Renderer Glass;
    [SerializeField]
    private Material OffMaterial;
    [SerializeField]
    private Material OnMaterial;
    private bool Action;
    public GameObject LocationMan;
    [SerializeField]
    private GameObject GhostCat;

    [SerializeField]
    private Material Offfly;
    [SerializeField]
    private Material OnFly;
    [SerializeField]
    private Renderer FireFlys;
    private bool temp;
    private void Awake()
    {
        Spotlight.enabled = false;
        PointLight.enabled = false;
        Halo.enabled = false;
        Glass.material = OffMaterial;
    }

    public void ToggleLight(bool OnOff)
    {
        if (OnOff == true)
        {
            Spotlight.enabled = true;
            PointLight.enabled = true;
            Halo.enabled = true;
            Glass.material = OnMaterial;

            if (Action == false)
            {
               
                    LocationMan.GetComponent<LocationMan>().NextLocationMan();
             
                Action = true;
            }
        }

        if (OnOff == false)
        {
            Spotlight.enabled = false;
            PointLight.enabled = false;
            Halo.enabled = false;
            Glass.material = OffMaterial;
        }
        temp = OnOff;
    }

    public void Glow(bool on)
    {
        if(temp == false)
        {
            Halo.enabled = false;
        }

        FireFlys.material = Offfly;
        if(on == true)
        {
            FireFlys.material = OnFly;
            Halo.enabled = true;
        }
    }
}
