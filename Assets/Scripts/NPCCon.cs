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
    private State MyState;
    [SerializeField]
    private int i = 0;
    private int PathIndex;
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
    }

    public void MoveToNextLocation()
    {
        agent.SetDestination(Locations[PathIndex].transform.position + Offset);
        PathIndex += 1;
    }

    private void Walk()
    {

    }

    private void Idle()
    {
    }
}
