using UnityEngine;
using UnityEngine.AI;

public class New_Enemy : MonoBehaviour
{
   public Transform target;
   private NavMeshAgent agent;
    public GameObject panel;
    public GameObject loseText;
    public GameObject winText;

    public float speedRate;

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
         
        agent.speed += speedRate*Time.deltaTime;

    }

    
     private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Caught Player");
            panel.SetActive(true);
            loseText.SetActive(true);
            winText.SetActive(false);
            
        }
    }

    public void resetSpeed()
    {
        agent.speed = 2f;
    }
}


