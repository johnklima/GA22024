using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmovement : MonoBehaviour
{
    public bool isPatrolling;
    public bool isFollowPlayer;

    public Transform target;
    private NavMeshAgent agent;

    public Transform[] pathPoints;
    private int curPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPatrolling)
        {
            
            if(agent.remainingDistance < 2.0f)
            {
                curPoint++;
                if(curPoint >= pathPoints.Length)
                {
                    curPoint = 0;
                }

                target = pathPoints[curPoint];
            }

            agent.SetDestination(target.position);

        }
        else if (isFollowPlayer)
        {
            if (agent.remainingDistance < 2.0f)
            {
                agent.isStopped = true;
            }

            if (Vector3.Magnitude(target.position - transform.position) > 6.0f)
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
        }




    }
}
