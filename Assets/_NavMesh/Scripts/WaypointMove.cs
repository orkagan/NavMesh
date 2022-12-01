using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject[] waypoints;
    public int currentWaypoint = 0;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 0;
    }
    private void Update()
    {
        if(waypoints[currentWaypoint]!=null) _agent.destination = waypoints[currentWaypoint].transform.position;
    }

    public void nextPosition()
    {
        if (currentWaypoint < waypoints.Length-1)
        {
            currentWaypoint++;
        }
    }
}
