using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public SpriteRenderer SpeechBubble;
    public Text TextRender;
    public GameObject NPC;
    private bool reset;
    private float timer;
    private string currentText;

    private void Awake()
    {
        SpeechBubble.enabled = false;
        TextRender.enabled = false;
    }

    public void Say(string sentence)
    {
        fullText = sentence;
        StartCoroutine(ShowText());
        SpeechBubble.enabled = true;
        NPC.GetComponent<VoiceModulator>().Speak = true;
        TextRender.enabled = true;
        reset = true;
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {
        if (reset == true)
        {
            timer += Time.deltaTime;
            if(timer > 3)
            {
                SpeechBubble.enabled = false;
                fullText = "";
                timer = 0f;
                reset = false;
                NPC.GetComponent<VoiceModulator>().Speak = false;
                TextRender.enabled = false;
            }
        }
    }
}
