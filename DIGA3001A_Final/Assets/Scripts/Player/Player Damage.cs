using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float health = 10f;
    public Playerhealth playerhealth;
    private SpriteRenderer spriteRenderer;
    private Color originalColour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColour = spriteRenderer.color;
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

            StartCoroutine(damageFlash());
        }
    }

    public IEnumerator damageFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColour;
    }
}
