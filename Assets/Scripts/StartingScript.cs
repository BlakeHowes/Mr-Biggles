using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScript : MonoBehaviour
{
    public float FadeSpeed;
    private bool Fade;
    public Renderer Shroud;
    public Renderer Shroud2;
    private Color theColorToAdjust;
    public float alpha;
    void Start()
    {
        Color theColorToAdjust = Shroud.material.color;
        alpha = 1f;

        theColorToAdjust.a = alpha;
        Shroud.material.color = theColorToAdjust;
        Shroud2.material.color = theColorToAdjust;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fade = true;



        }
    
        if(Fade == true)
        {
            if(alpha > 0f)
            {
                alpha -= FadeSpeed;
                theColorToAdjust.a = alpha;
                Shroud.material.color = theColorToAdjust;
                Shroud2.material.color = theColorToAdjust;
            }
            if(alpha <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
