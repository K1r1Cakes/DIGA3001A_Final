using UnityEngine;
using UnityEngine.AI;

public class New_Enemy : MonoBehaviour
{
   public Transform target;
   private NavMeshAgent agent;
  



     Rigidbody2D rb;

     private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

        agent.SetDestination(target.position);
         
        agent.speed = 2f;

    }

    
   

}


