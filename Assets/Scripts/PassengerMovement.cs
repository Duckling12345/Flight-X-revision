using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassengerMovement : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshagent;

    private void Awake()
    {
       navMeshagent = GetComponent<NavMeshAgent>(); 
    }

    public void Update()
    {
       navMeshagent.destination = movePositionTransform.position;
    }
}
