using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   public GameObject ememy1;
   public GameObject enemy2;

   private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            ememy1.SetActive(true);
            enemy2.SetActive(true);
        }
    }
}
