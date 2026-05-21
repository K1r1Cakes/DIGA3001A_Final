using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float health = 10f;
    public Playerhealth playerhealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Damage");
            playerhealth.TakeDamage(health);
        }
    }
}
