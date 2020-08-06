using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoManager : MonoBehaviour
{
    public enum Emotion { Happy, Idle, IdleTalking };
    public Emotion currentEmotion = Emotion.Idle;

    public Texture happyTexture;
    public Texture idleTexture;
    public Texture idleTalkingTexture;

    private float timer;
    private bool meow;
    private float timer2;
    private bool happy;
    [SerializeField]
    private Material mat;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentEmotion)
        {
            case Emotion.Happy:
                mat.SetTexture("_MainTex", happyTexture);
                break;
            case Emotion.Idle:
                mat.SetTexture("_MainTex", idleTexture);
                break;
            case Emotion.IdleTalking:
                mat.SetTexture("_MainTex", idleTalkingTexture);
                break;

        }

        if(meow == true)
        {
            currentEmotion = Emotion.IdleTalking;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                currentEmotion = Emotion.Idle;
                meow = false;
                timer = 0f;
            }
        }

        if (happy == true)
        {
            currentEmotion = Emotion.Happy;
            timer2 += Time.deltaTime;
            if (timer2 > 4)
            {
                currentEmotion = Emotion.Idle;
                happy = false;
                timer2 = 0f;
            }
        }
    }

    public void StartTalking()
    {
        meow = true;
    }

    public void Happy()
    {
        happy = true;
    }
}
