using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float totalEnemyHealth = 30f;
    public float enemyDamage = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
           
            if (totalEnemyHealth > 0)
            {
                Debug.Log("Enemy Damage");
                totalEnemyHealth -= enemyDamage;

                Bullet bullet = collision.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.BulletHit(); 
                }
               
            }
            else
            {
                Debug.Log("Enemy dead");
                Destroy(this.gameObject);
            }
            
            
        }
    }
}
