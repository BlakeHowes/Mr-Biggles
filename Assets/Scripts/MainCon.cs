using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCon : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float maxVelocityChange;
    [SerializeField]
    private float radius;


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Meow();
        }
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Move();
        }
        else
        {
            transform.forward = Vector3.back;
        }
    }

    private void Meow()
    {
        Collider[] NearbyLamps = Physics.OverlapSphere(transform.position, radius);
        foreach (var Lamp in NearbyLamps)
        {
            if(Lamp.gameObject.tag == "Lamp")
            {
                bool TurnOn = true;
                Lamp.GetComponent<LampCon>().ToggleLight(TurnOn);
            }
        }
    }

    private void Move()
    {
        var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Speed;
        var velocityChange = (targetVelocity - rb.velocity);

        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
        transform.forward = targetVelocity.normalized;

        transform.GetChild(1).transform.localRotation = Quaternion.Euler(new Vector3(Mathf.Max(Mathf.Abs(Input.GetAxis("Horizontal")), Mathf.Abs(Input.GetAxis("Vertical"))) * 30, 0, 0));
    }
}
