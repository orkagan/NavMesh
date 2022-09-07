using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (Vector3.Distance(_agent.destination, transform.position)<2f)
        {
            float randomX = Random.Range(0f, 10f);
            float randomZ = Random.Range(0f, 10f);
            Vector3 randomPosition = new Vector3(randomX, transform.position.y, randomZ);

            _agent.destination = randomPosition;
        }
    }
}
