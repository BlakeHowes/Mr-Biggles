using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMan : MonoBehaviour
{
    public List<GameObject> NPCs = new List<GameObject>();
    public GameObject GhostCat;
    public GameObject DialogueCon;
    private int index;

    public void NextLocationMan()
    {
        foreach (GameObject NPC in NPCs)
        {
            NPC.GetComponent<NPCCon>().MoveToNextLocation();
            GhostCat.GetComponent<EmoManager>().Happy();
            if(index == 0)
            {
                DialogueCon.GetComponent<Dialogue>().Goidle();
            }
            index += 1;
        }
    }

    void Update()
    {
        
    }
}
