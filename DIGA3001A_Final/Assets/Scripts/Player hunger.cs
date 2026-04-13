using UnityEngine;

public class Playerhunger : MonoBehaviour
{
    public float hungerTimer = 5f;
    public float globalTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTimer = hungerTimer;
    }

    // Update is called once per frame
    void Update()
    {
        globalTimer -= Time.deltaTime;

        if(globalTimer <= 0)
        {
            loseHunger();
            globalTimer = hungerTimer;
        }
        
    }

    public void loseHunger()
    {
       
        
             Debug.Log("Half hunger bar");
        

       

        
        
    }
}
