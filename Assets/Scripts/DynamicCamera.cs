using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicCamera : MonoBehaviour
{
    public Transform GhostCat;

    [SerializeField]
    private float SmoothSpeed;
    public Vector3 offset;
    [SerializeField]
    private SpriteRenderer Pressx;
    private float timer;
    private float temp;
    private bool toggle;
    private bool NotInCutScene = true;
    private bool Finalcam;
    [SerializeField]
    private float timer2;
    private bool toggle2;
    public GameObject MainNPC;
    private void Start()
    {
        Pressx.enabled = false;

        temp = SmoothSpeed;
        SmoothSpeed = temp / 3;
    }

    void FixedUpdate()
    {
        Vector3 Pos1 = GhostCat.position + offset;
        Vector3 Pos2 = Vector3.Lerp(transform.position, Pos1, SmoothSpeed);
        if(NotInCutScene == true)
        {
            transform.position = Pos2;
        }

        timer += Time.deltaTime;

        if(timer > 3)
        {
            if(toggle == false)
            {
                SmoothSpeed = temp;
                Pressx.enabled = true;
            }

        }

        if (Input.GetKey(KeyCode.X))
        {
            Pressx.enabled = false;
            toggle = true;
        }

        if (Finalcam == true)
        {
            timer2 += Time.deltaTime;
            if(timer2 > 15)
            {
                if(toggle2 == false)
                {
                    Quaternion rot2 = Quaternion.Euler(-2.131f, -23.475f, 0);
                    Vector3 pos3 = new Vector3(58.15f, 0.22f, 46.64f);
                    transform.rotation = rot2;
                    transform.position = pos3;
                    MainNPC.GetComponent<NPCCon>().MoveToNextLocation();

                    toggle2 = true;
                }
                if(toggle2 == true)
                {
                    if(timer2 > 20)
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                }
            }
        }
    }

    public void StartCutScene()
    {
        NotInCutScene = false;
        Vector3 pos3 = new Vector3(56.23f, 0.4f, 51.04f);
        Quaternion rot = Quaternion.Euler(25.142f, 135.784f, 0);
        transform.position = pos3;
        transform.rotation = rot;
        Finalcam = true;
    }
 
}
