using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimator : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_agent.velocity.magnitude > 0.1f)
        {
            _anim.SetBool("IsWalking", true);
        }
        else
        {
            _anim.SetBool("IsWalking", false);
        }
    }
}
