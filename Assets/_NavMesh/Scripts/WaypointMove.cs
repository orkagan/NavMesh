using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    public List<GameObject> waypoints;
    public GameObject endPoint;
    [SerializeField]
    private GameObject _currentWaypoint;

    private State _state;
    public enum State
    {
        Collecting, //finding waypoint collectables within reach
        Progressing, //trying to get to the end goal
        Finished
    }
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentWaypoint = null;
        nextPosition();
    }
    private void Update()
    {
        switch (_state)
        {
            case State.Collecting:
                if (!_agent.hasPath)
                {
                    Debug.Log("No path, retargeting");
                    nextPosition();
                }
                break;
            case State.Progressing:
                _agent.destination = endPoint.transform.position;
                break;
            case State.Finished:
                //agent is done, time for retirement
                gameObject.SetActive(false);
                break;
            default:
                Debug.Log("Error in state machine");
                break;
        }
    }

    /// <summary>
    /// Sets the destination of agent to the nearest waypoint (based on shortest path).
    /// </summary>
    public void nextPosition()
    {
        //if out of waypoints, then go for the end
        if (waypoints.Count<=0)
        {
            _state = State.Progressing;
        }
        else
        {
            _state = State.Collecting;
        }
        
        float closestTargetDistance = float.MaxValue;
        NavMeshPath Path = null;
        NavMeshPath ShortestPath = null;

        //for each waypoint/collectable in list
        for (int i = 0; i < waypoints.Count; i++)
        {
            //if waypoints[i] is null or already the target continue to next loop
            if (waypoints[i] == null || _currentWaypoint==waypoints[i])
            {
                continue;
            }

            //calculate path to waypoint[i]
            Path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, waypoints[i].transform.position, _agent.areaMask, Path))
            {
                float distance = CalculatePathDistance(Path);
                //if the distance of the path is closer then overwrite closestTargetDistance
                if (distance < closestTargetDistance)
                {
                    closestTargetDistance = distance;
                    ShortestPath = Path;
                    _currentWaypoint = waypoints[i];
                }
            }
        }
        /*if (ShortestPath != null)
        {
            _agent.SetPath(ShortestPath);
        }*/
        if (_currentWaypoint != null)
        {
            _agent.destination = _currentWaypoint.transform.position;
        }
    }
    public float CalculatePathDistance(NavMeshPath path)
    {
        float distance = Vector3.Distance(transform.position, path.corners[0]);

        for (int i = 1; i < path.corners.Length; i++)
        {
            distance += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return distance;
    }
    public void Finished()
    {
        _state = State.Finished;
    }
}
