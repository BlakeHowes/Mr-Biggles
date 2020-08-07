using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<GameObject> NPCs = new List<GameObject>();
    public List<string> DialogueList = new List<string>();

    public enum TalkState { Start, TrickorTreating, GoodnightBiggs, idle };
    public TalkState CurrentDialogue = TalkState.Start;
    public bool Begin;
    private float timer;
    private bool repeat = true;

    public Text NPC1;
    public Text NPC2;
    public void Goidle()
    {
        CurrentDialogue = TalkState.idle;
    }


    void Update()
    {
        switch (CurrentDialogue)
        {
            case TalkState.Start:
                StartSpeech();
                break;
            case TalkState.TrickorTreating:
                StartSpeech();
                break;
            case TalkState.GoodnightBiggs:
                StartSpeech();
                break;
            case TalkState.idle:
                idlechat();
                break;
        }
    }

    public void StartSpeech()
    {
        if (Begin == true)
        {
            timer += Time.deltaTime;
            if (timer > 7)
            {
                NPCs[0].GetComponent<SpeechManager>().Say(DialogueList[0]);
                timer = 0f;
            }

        }
    }
    public void TickOrTreat()
    {
        NPC2.fontSize = 230;
        NPCs[1].GetComponent<SpeechManager>().Say(DialogueList[1]);
    }

    public void Goodnight()
    {
        NPC1.fontSize = 190;
        NPCs[0].GetComponent<SpeechManager>().Say(DialogueList[2]);
    }

    public void idlechat()
    {

    }
}