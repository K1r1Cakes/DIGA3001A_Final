using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public GameObject deathPanel;
    public WarningMessagePanel warn;
    private bool warningShown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

        if(healthAmount > 20)
        {
            warningShown = false;
        }

        if (healthAmount <= 20 && !warningShown)
        {
            warn.showWarning("Health is low!", 2f);
            warningShown = true;
        }
        
        if (healthAmount  == 0)
        {
            //Lose condition
            deathPanel.SetActive(true);
            PauseController.SetPause(true);
            Debug.Log("Lose");
        }
    }

     public void fillHealth(float health)
    {
        if (healthAmount < 100)
        {
            healthAmount += health;
            healthBar.fillAmount = healthAmount/100f;
        }

        if (healthAmount > 100)
        {
            healthAmount = 100;
        }
    }
}
