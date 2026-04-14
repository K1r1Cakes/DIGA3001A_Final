using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhealth : MonoBehaviour
{
    public float playerHealth = 3f;
    public Image[] heartImage;
    public TextMeshProUGUI deathText;
    public Pickup pickup;
    public bool isHealth = false;
    public AudioSource audioSource;
    public AudioSource heartbeatSource;
    public AudioSource endGame;
   
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
                deathText.text = "Player is dead";
                endGame.Play();
            }

        }
    }

    public void playerDamage()
    {
        playerHealth -= 0.5f ;
        audioSource.Play();

        if (playerHealth <= 1f)
        {
            deathText.text = "You are low on health. Heal now!";

            if (!heartbeatSource.isPlaying)
            {
               heartbeatSource.Play(); 
            }
            
            isHealth = true;
        }
        else
        {
            isHealth = false;
            heartbeatSource.Stop();
        }

        if (playerHealth < 0)
        {
            playerHealth = 0;
            audioSource.Stop();
            heartbeatSource.Stop();
        }

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

    public void heartHeal()
    {
        if (playerHealth < heartImage.Length)
        {
            playerHealth += 0.5f;
        }

        if (playerHealth > heartImage.Length)
        {
            playerHealth = heartImage.Length;
        }

        if (playerHealth > 1f)
        {
            heartbeatSource.Stop();
            isHealth =false;
        }
        heartFill();
    }
}
