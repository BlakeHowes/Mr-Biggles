using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoManager : MonoBehaviour
{
    public enum Emotion {Happy, Idle, IdleTalking};
    public Emotion currentEmotion = Emotion.Idle;

    public Texture happyTexture;
    public Texture idleTexture;
    public Texture idleTalkingTexture;

    private Material mat;

    void Start()
    {
        mat = transform.GetChild(0).GetComponent<Renderer>().sharedMaterial;
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
    }
}
