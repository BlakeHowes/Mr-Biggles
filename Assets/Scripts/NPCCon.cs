using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCon : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Locations = new List<GameObject>();
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private NavMeshAgent agent;
    public GameObject DialogueCon;
    public Camera Maincam;
    private State MyState = State.IDLE;
    [SerializeField]
    private int i = 0;
    private int PathIndex;
    private bool toggle;
    private float timer3;
    public float rotateSpeed;
    [SerializeField]
    private float timer2;
    private float timer1;
    private bool reset;
    public ParticleSystem Candy1;
    public ParticleSystem Candy2;
    public ParticleSystem Candy3;
    private bool house1;
    private bool house2;
    private bool house3;
    private bool house4;
    void Awake()
    {
        PathIndex = 0;
    }

    public enum State
    {
        WALK,
        IDLE
    }

    void Update()
    {
        switch (MyState)
        {
            case State.WALK:
                Walk();
                break;
            case State.IDLE:
                Idle();
                break;
        }

        if(transform.position.x > 53)
        {
            if(toggle == false)
            {
                Maincam.GetComponent<DynamicCamera>().StartCutScene();
                toggle = true;
                MoveToNextLocation();
            }

        }

        if (Vector3.Distance(transform.position, Locations[0].transform.position) < 2)
        {
            if(house1 == false)
            {
                DialogueCon.GetComponent<Dialogue>().TickOrTreat();
                house1 = true;
            }

            MyState = State.IDLE;
            if (Candy1 != null)
            {
                Candy1.Play(true);
            }
        }

        if (Vector3.Distance(transform.position, Locations[1].transform.position) < 2)
        {
            if (house2 == false)
            {
                DialogueCon.GetComponent<Dialogue>().TickOrTreat();
                house2 = true;
            }

            MyState = State.IDLE;
            if (Candy1 != null)
            {
                Candy2.Play(true);
            }

        }

        if (Vector3.Distance(transform.position, Locations[2].transform.position) < 2)
        {
            if (house3 == false)
            {
                DialogueCon.GetComponent<Dialogue>().TickOrTreat();
                house3 = true;
            }

            MyState = State.IDLE;
            if(Candy1 != null)
            {
                Candy3.Play(true);
            }
        }

        if (Vector3.Distance(transform.position, Locations[4].transform.position) < 2)
        {
            if (house4 == false)
            {
                DialogueCon.GetComponent<Dialogue>().Goodnight();
                house4 = true;
            }

            MyState = State.IDLE;
        }

        if(reset == true)
        {
            timer2 += Time.deltaTime;
            if(timer2 > 2)
            {
                timer2 = 0;
                MyState = State.WALK;
                reset = false;
            }
        }
    }

    public void MoveToNextLocation()
    {
        agent.SetDestination(Locations[PathIndex].transform.position + Offset);
        PathIndex += 1;
        reset = true;
    }

    private void Walk()
    {
        timer3 += Time.deltaTime;
        if (timer3 < 0.3)
        {
            transform.Rotate(0, 0, rotateSpeed, Space.Self);
        }
        if (timer3 > 0.3)
        {
            transform.Rotate(0, 0, -rotateSpeed, Space.Self);
        }
        if (timer3 > 0.6)
        {
            timer3 = 0f;
        }
    }

    private void Idle()
    {

    }
}
