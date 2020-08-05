using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VoiceModulator : MonoBehaviour
{
    [SerializeField]
    private float pitch;
    [SerializeField]
    private float PitchRange;
    [SerializeField]
    private AudioClip Voice;
     [SerializeField]
    private float WordSpeed;
    [SerializeField]
    private float WordClumping;
    [SerializeField]
    private float WordClumpingRange;
    [SerializeField]
    private float pause;
    [SerializeField]
    private float SpeedRange;
    [SerializeField]
    private float PauseRange;

    private AudioSource Speaker;

    private float WordTimer;
    public bool Speak;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Counter;
    [SerializeField]
    private bool Spoke;
    private float WordClumpingTemp;
    void Start()
    {
        Speaker = GetComponent<AudioSource>();
        Speaker.pitch = pitch;
        WordClumpingTemp = WordClumping;
    }

    public void Update()
    {
        
        if(Speak == true)
        {
            WordTimer += Time.deltaTime;
            if(WordTimer > Speed)
            {
                Speaker.pitch = Random.Range(pitch - PitchRange, pitch + PitchRange);
                WordTimer = 0f;
                Speaker.PlayOneShot(Voice);
                Spoke = true;
                Counter += 1;

            }

            if(Spoke == true)
            {

                Speed = WordSpeed / (3 + Random.Range(WordSpeed - SpeedRange, WordSpeed + SpeedRange) );
            }

            if(Counter >= WordClumpingTemp)
            {
                WordClumpingTemp = Random.Range(WordClumping - WordClumpingRange, WordClumping + WordClumpingRange);
                Spoke = false;
                Counter = 0f;
                Speed = WordSpeed * (pause + Random.Range(pause, PauseRange));
            }
        }

    }
}
