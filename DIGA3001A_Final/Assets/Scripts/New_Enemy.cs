using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class New_Enemy : MonoBehaviour
{
   public Transform target;
   public Transform[] patrolPoints;
   private NavMeshAgent agent;
   private float patrolWaitTime = 2f;
   private float stopAtDistance = 1f;
  private int currentPatrolIndex;
  private bool isWaiting;



     Rigidbody2D rb;

     private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
         
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
       
        GoToNextPatrolPoint();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
           if (PauseController.isGamePaused)
         {
            agent.speed = 0;
            return;
        }

       // agent.SetDestination(target.position);
         Patrol();
        agent.speed = 2f;

    }

    private void Patrol()
    {
        if (isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= stopAtDistance)
        {
            StartCoroutine(waitAtPatrolPoint());
        }
    }
    private IEnumerator waitAtPatrolPoint()
    {
        isWaiting = true;
        agent.isStopped = true;


        yield return new WaitForSeconds(patrolWaitTime);

        agent.isStopped = false;
        GoToNextPatrolPoint();
        isWaiting = false;
    }
    private void GoToNextPatrolPoint()
    {
        if(patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; //make this random
    }
   

}


