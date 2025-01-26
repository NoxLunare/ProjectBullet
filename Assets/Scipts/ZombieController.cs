using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent=null;
    public Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        GetReferences(); 
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        agent.SetDestination(target.position);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
