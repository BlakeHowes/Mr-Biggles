using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position = Pos2;

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
    }

 
}
