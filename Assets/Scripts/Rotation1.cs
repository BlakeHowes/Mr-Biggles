using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    public GameObject Body;
    public float height;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = new Vector3(0f, height, 0f);
        transform.position = Body.transform.position + offset;
        var Direction = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        transform.rotation = Quaternion.LookRotation(Direction);
    }
}
