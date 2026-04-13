using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float playerHealth = 3f;
    public Image[] heartImage;
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
            Debug.Log("Player damage");

            if(playerHealth > 0)
            {
                playerDamage();
            }
            else 
            {
                Debug.Log("Player is dead");
            }

        }
    }

    void playerDamage()
    {
        playerHealth -= 0.5f ;
        heartFill();
    }

    void heartFill()
    {
        for (int i = 0; i < heartImage.Length; i++)
    {
        float remainingHealth = playerHealth - i;

        if (remainingHealth >= 1)
        {
            heartImage[i].fillAmount = 1f; // full heart
        }
        else if (remainingHealth > 0)
        {
            heartImage[i].fillAmount = 0.5f; // half heart
        }
        else
        {
            heartImage[i].fillAmount = 0f; // empty heart
        }
    }
    }
}
