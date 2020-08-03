using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject Body;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Body.transform.position;
        var Direction = new Vector3(-Input.GetAxis("Horizontal"), -2, -Input.GetAxis("Vertical"));
        transform.rotation = Quaternion.LookRotation(Direction);
    }
}
