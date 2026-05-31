using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Runtime.CompilerServices;

public enum enemyState
{
    Patrolling,
    Following
}

public class New_Enemy : MonoBehaviour
{
   public Transform target;
   public Transform[] patrolPoints;
   public Transform raycastOrigin;
   private NavMeshAgent agent;
   private Animator animator;
   private float patrolWaitTime = 2f;
   private float stopAtDistance = 1f;
   private float detectionRange = 10f;
   private float viewAngle = 90f;
   private float losePlayerTime = 3f;
  private int currentPatrolIndex;
  private bool isWaiting;
  private enemyState state = enemyState.Patrolling;
  private float timeSinceLostPlayer;



     Rigidbody2D rb;

    public void Initialize(Transform player, Transform[] points)
    {
        target = player;
        patrolPoints = points;

        GoToNextPatrolPoint();
    }

     private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
         
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
       // GoToNextPatrolPoint();
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
       var distanceToPlayer = Vector3.Distance(target.position, transform.position);

       switch (state)
        {
            case enemyState.Patrolling:
                Patrol();
                if(distanceToPlayer <= detectionRange && CanSeePlayer())
                {
                    state = enemyState.Following;
                }

                break;
            case enemyState.Following:
                FollowPlayer();
                if (!CanSeePlayer())
                {
                    timeSinceLostPlayer += Time.deltaTime;
                    if(timeSinceLostPlayer >= losePlayerTime)
                    {
                        state = enemyState.Patrolling;
                        GoToClosestPatrolPoint();
                    }
                }
                else
                {
                    timeSinceLostPlayer = 0f;
                }
                break;
        }
        
        agent.speed = 2f;

    }

    private void FollowPlayer()
    {
        agent.SetDestination(target.position);
        animator.SetBool("isWalking", true);
        animator.SetFloat("InputX", agent.velocity.x);
        animator.SetFloat("InputY", agent.velocity.y);
       // Debug.Log("Follwing");
    }
    private void Patrol()
    {
        if (isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= stopAtDistance)
        {
            StartCoroutine(waitAtPatrolPoint());
        }

       // Debug.Log("Patrollimg");
    }
    private IEnumerator waitAtPatrolPoint()
    {
        isWaiting = true;
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.SetFloat("InputX", agent.velocity.x);
        animator.SetFloat("InputY", agent.velocity.y);

        yield return new WaitForSeconds(patrolWaitTime);
        

        agent.isStopped = false;
        animator.SetBool("isWalking", true);
        animator.SetFloat("InputX", agent.velocity.x);
        animator.SetFloat("InputY", agent.velocity.y);
        
        GoToNextPatrolPoint();
        isWaiting = false;
    }

    private void GoToClosestPatrolPoint()
    {
        if(patrolPoints.Length == 0) return;

        var closestIndex =0;
        var closestDistance = float.MaxValue;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            var distance = Vector3.Distance(transform.position, patrolPoints[i].position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        currentPatrolIndex = closestIndex;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
    private void GoToNextPatrolPoint()
    {
        if(patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; //make this random
    }

    private bool CanSeePlayer()
    {
        Vector2 dirToPlayer = target.position - raycastOrigin.position;

    RaycastHit2D hit = Physics2D.Raycast(
        raycastOrigin.position,
        dirToPlayer.normalized,
        detectionRange
    );

    Debug.DrawRay(
        raycastOrigin.position,
        dirToPlayer.normalized * detectionRange,
        Color.red
    );

    if (hit.collider != null)
    {
        Debug.Log("Hit: " + hit.collider.name);

        return hit.transform == target;
    }

    return false;
    }
   
    private bool IsFacingPlayer()
    {
         Vector2 dirToPlayer = (target.position - transform.position).normalized;
         Vector2 moveDirection = agent.velocity.normalized;

         if(moveDirection == Vector2.zero)
        {
            return true;
        }

        // Use enemy's right direction in 2D
        float angle = Vector2.Angle(moveDirection, dirToPlayer);

        return angle <= viewAngle / 2f;
    }

    private bool HasClearPathToPlayer()
    {
        Vector2 dirToPlayer = target.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer.normalized, dirToPlayer.magnitude);
        Debug.DrawRay(transform.position, dirToPlayer, Color.red);
        
        if(hit.collider != null)
        {
            return hit.transform == target;
        }

        return false;
    }
}


