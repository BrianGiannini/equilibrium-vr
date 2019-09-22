using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;

    void Update()
    {
        
    }

    public void MoveAgent()
    {
        agent.SetDestination(player.position);
    }
}
