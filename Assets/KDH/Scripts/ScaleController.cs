using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class ScaleController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    private bool _isStop = false;
    public void OnStop()
    {
        if (!_isStop)
        {
            PauseAllExceptPlayer(gameObject);
            _isStop = !_isStop;
        }
        else
        {
            ResumeAll();
            _isStop = !_isStop;
        }
    }

    //�ش� ������Ʈ�� ������ �͵��� ����.
    private void PauseAllExceptPlayer(GameObject gameObject)
    {
        // Rigidbody ������Ʈ�� ����
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject != gameObject)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }

        // Animator ������Ʈ�� ����
        Animator[] allAnimators = FindObjectsOfType<Animator>();
        foreach (Animator animator in allAnimators)
        {
            if (animator.gameObject != gameObject)
            {
                animator.enabled = false;
            }
        }

        // NavMeshAgent ������Ʈ�� ����
        NavMeshAgent[] allNavMeshAgents = FindObjectsOfType<NavMeshAgent>();
        foreach (NavMeshAgent agent in allNavMeshAgents)
        {
            if (agent.gameObject != gameObject)
            {
                agent.isStopped = true;
            }
        }
    }

    private void ResumeAll()
    {
        // Rigidbody ������Ʈ�� �ٽ� ����
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            rb.isKinematic = false;
        }

        // Animator ������Ʈ�� �ٽ� ����
        Animator[] allAnimators = FindObjectsOfType<Animator>();
        foreach (Animator animator in allAnimators)
        {
            animator.enabled = true;
        }

        // NavMeshAgent ������Ʈ�� �ٽ� ����
        NavMeshAgent[] allNavMeshAgents = FindObjectsOfType<NavMeshAgent>();
        foreach (NavMeshAgent agent in allNavMeshAgents)
        {
            agent.isStopped = false;
        }
    }
}
