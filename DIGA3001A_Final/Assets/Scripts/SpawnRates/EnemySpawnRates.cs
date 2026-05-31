using UnityEngine;

public class EnemySpawnRates : MonoBehaviour
{
    public EnemySpawnPoints[] enemySpawnPoints;
   // public New_Enemy newEnemy;
    public GameObject enemy;
    public float enemyTimer;
    public float timeBetweenEnemySpawns;
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

        enemyTimer += Time.deltaTime;

        if (enemyTimer > timeBetweenEnemySpawns)
        {
            enemyTimer = 0;

            foreach(EnemySpawnPoints spawnPoint in enemySpawnPoints)
            {
                if(Random.value < 0.5f)
                {
                    GameObject newEnemy = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
                    New_Enemy enemyScript = newEnemy.GetComponent<New_Enemy>();
                    enemyScript.Initialize(GameObject.FindGameObjectWithTag("Player").transform, spawnPoint.patrolPoints);

                }
            }
        }
    }
}
