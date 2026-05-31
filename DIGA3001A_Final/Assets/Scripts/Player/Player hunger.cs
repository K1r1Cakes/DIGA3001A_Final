using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.Common;

public class Playerhunger : MonoBehaviour
{
    public float hungerTimer = 5f;
    public float globalTimer;
    public float hungerAmount = 100f;
    public float hungerDamage = 10f;
    public Image hungerBar;
    public Playerhealth playerhealth;
   
    public bool isHungry = false;
    public WarningMessagePanel warn;
    private bool warningShown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTimer = hungerTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isGamePaused)
        {
            return;
        }
        
        globalTimer -= Time.deltaTime;

        if(globalTimer <= 0)
        {
            if (hungerAmount > 0)
            {
              loseHunger(hungerDamage);
              globalTimer = hungerTimer; 
            }
            else
            {
             Debug.Log("Player starved to death");
             playerhealth.TakeDamage(10);
            }
            globalTimer = hungerTimer;

             if(hungerAmount > 20)
            {
                warningShown = false;
            }
            
             if(hungerAmount < 20 && !warningShown)
            {
                warn.showWarning("Hunger is low! Eat immediatley.", 2f);
                warningShown = true;
            }
        }
        
        
    }


    public void loseHunger(float hunger)
    {
        hungerAmount -= hunger;
        hungerBar.fillAmount = hungerAmount/100f;
    }

     public void fillHunger(float hunger)
    {
        if (hungerAmount < 100)
        {
            hungerAmount += hunger;
            hungerBar.fillAmount = hungerAmount/100f;
        }

        if (hungerAmount > 100)
        {
            hungerAmount = 100;
        }
    }
 }
