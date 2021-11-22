using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{

    public Camera cam;

    private NavMeshAgent agent;
    public Transform finishLine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, finishLine.position.z));
    }
    
}