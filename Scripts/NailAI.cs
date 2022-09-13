using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NailAI : MonoBehaviour
{
    [Range(0.5f, 50)]
    public float detectDistance;
    public Transform[] points;
    NavMeshAgent agent;

    private void Start()
    {
        int destinationIndex = Random.Range(0,4);
        agent = GetComponent<NavMeshAgent>();

        if(agent != null)
        {
            agent.destination = points[destinationIndex].position;
        }
    }

    private void Update()
    {
        int destinationIndex = Random.Range(0,4);
        float dist = agent.remainingDistance;
        if(dist <= 0.05f)
        {
            destinationIndex++;
            if (destinationIndex > points.Length - 1)
                destinationIndex = 0;
            agent.destination = points[destinationIndex].position;
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }

}
