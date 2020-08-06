﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<GameObject> NPCs = new List<GameObject>();
    public List<string> DialogueList = new List<string>();

    public enum TalkState { Start, TrickorTreating, GoodnightBiggs,idle};
    public TalkState CurrentDialogue = TalkState.Start;
    public bool Begin;
    private float timer;
    private bool repeat = true;

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

    }

    public void Goodnight()
    {

    }

    public void idlechat()
    {

    }
}
