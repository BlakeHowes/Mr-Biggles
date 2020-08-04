using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCon : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Locations = new List<GameObject>();
    private NavMeshAgent agent;
    private State MyState;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Locations[0].transform.position);
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
    }

    private void Walk()
    {

    }

    private void Idle()
    {

    }
}
