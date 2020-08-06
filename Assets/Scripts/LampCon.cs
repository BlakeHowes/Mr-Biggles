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
    public List<GameObject> NPCs = new List<GameObject>();
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
                foreach (GameObject NPC in NPCs)
                {
                    NPC.GetComponent<NPCCon>().MoveToNextLocation();
                }
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
    }
}
