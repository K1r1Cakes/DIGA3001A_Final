using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject[] foodSpawnPoints;
    public GameObject cherry;
    public float foodTimer;
    public float timeBetweenFoodSpawns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isGamePaused)
        {
            return;
        }

        foodTimer += Time.deltaTime;

        if(foodTimer > timeBetweenFoodSpawns)
        {
            foodTimer =0;
            
            foreach(GameObject spawnPoint in foodSpawnPoints)
            {
                if(Random.value < 0.5)
                {
                    Instantiate(cherry, spawnPoint.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
