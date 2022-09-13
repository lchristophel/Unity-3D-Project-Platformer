using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NailAI : MonoBehaviour
{
    [Range(0.5f, 50)]
    public float detectDistance;
    public Transform[] points;
    private NavMeshAgent agent;
    private Transform player;
    private int run = 2;
    private int walk = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        int destinationIndex = Random.Range(0,4);
        agent = GetComponent<NavMeshAgent>();

        if(agent != null)
        {
            agent.destination = points[destinationIndex].position;
        }
    }

    private void Update()
    {
        Walk();
        SearchPlayer();
    }

    public void SearchPlayer()
    {
        int destinationIndex = Random.Range(0,4);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            agent.destination = player.position;
            agent.speed = run;
        }
        else
        {
            agent.speed = walk;
            agent.destination = points[destinationIndex].position;
        }
    }

    public void Walk()
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
