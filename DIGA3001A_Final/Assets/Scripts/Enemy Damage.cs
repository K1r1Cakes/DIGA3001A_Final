using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public float totalEnemyHealth = 40f;
    public float enemyDamage = 10f;
    public GameObject experience;
    public PlayerSword playerSword;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSword = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSword>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Enemy Damage"); 
            StartCoroutine(DamageFlash());
           totalEnemyHealth -= enemyDamage;
 
                Bullet bullet = collision.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.BulletHit(); 
                }

            if (totalEnemyHealth <= 0)
            {
               Debug.Log("Enemy dead");
                Instantiate(experience, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
               
               
            }
            
            
        }

        if (collision.CompareTag("SwordRange") && playerSword.isSwinging == true)
        {
            totalEnemyHealth -= enemyDamage;
            StartCoroutine(DamageFlash());
            
             if (totalEnemyHealth <= 0)
            {
               Debug.Log("Enemy dead");
                Instantiate(experience, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
               
               
            }
        }
    }

     IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = originalColor;
    }

}
