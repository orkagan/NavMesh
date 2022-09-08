using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaMovementModifier : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] float _speed;
    [SerializeField] float _grassSpeed;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);

        int GrassMask = 1 << NavMesh.GetAreaFromName("TallGrass");
        int filtered = hit.mask & GrassMask;
        //0 means we didn't hit the grass
        //!0 means we are on grass

        if (filtered == 0)
        {
            _agent.speed = _speed;
        }
        else
        {
            _agent.speed = _grassSpeed;
        }

        Debug.Log(hit.mask);
    }
}
