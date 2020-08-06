using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainCon : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float maxVelocityChange;
    [SerializeField]
    private float radius;

    private AudioSource CatSounds;
    [SerializeField]
    private AudioClip CatMeow1;
    private Rigidbody rb;
    private bool Zrelease;
    private float KeyTimer;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CatSounds = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && Zrelease == true)
        {
            Meow();
            Zrelease = false;
        }

        if (!Input.GetKey(KeyCode.X))
        {
            if(Zrelease == false)
            {
                KeyTimer += Time.deltaTime;
            }

            if(KeyTimer > 1)
            {
                Zrelease = true;
                KeyTimer = 0f;
            }
        }
        timer += Time.deltaTime;
        if(timer > 0.1)
        {
            timer = 0;
            CheckForLamps();
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
            rb.velocity = Vector3.zero;
        }
    }

    private void CheckForLamps()
    {
        Collider[] NearbyLamps = Physics.OverlapSphere(transform.position, radius);
        foreach (var Lamp in NearbyLamps)
        {
            if (Lamp.gameObject.tag == "Lamp")
            {
                bool on = true;
                Lamp.GetComponent<LampCon>().Glow(on);
            }
        }
    }

    private void Meow()
    {
        CatSounds.PlayOneShot(CatMeow1);
        GetComponent<EmoManager>().StartTalking();
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
