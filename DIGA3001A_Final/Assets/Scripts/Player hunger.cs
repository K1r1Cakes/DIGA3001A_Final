using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhunger : MonoBehaviour
{
    public float hungerTimer = 5f;
    public float globalTimer;
    public float hungerAmount = 100f;
    public float hungerDamage = 10f;
    public Image hungerBar;
   
    public bool isHungry = false;
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
             //playerhealth.playerDamage();
            }
            globalTimer = hungerTimer;
        }
        
        
    }

//     void loseHunger()
//     {
//         playerHunger -= 10f;

//         if (playerHunger <= 1)
//         {
//            // hungerText.text = "You are starving. Eat now!";
//             isHungry = true;
//         }
//         else
//         {
//             isHungry = false;
//         }

//         if (playerHunger < 0)
//         {
//             playerHunger = 0;
//         }

//         hungerFill();
//     }
//     void hungerFill()
//     {
//      

//         for(int i = 0; i < hungerImage.Length; i++)
//         {
//             float remainingHunger = playerHunger - i;

//             if (remainingHunger >= 1)
//             {
//                 hungerImage[i].fillAmount = 1f;
//             }
//             else if(remainingHunger > 0)
//             {
//                 hungerImage[i].fillAmount = 0.5f;
//             }
//             else
//             {
//                 hungerImage[i].fillAmount =0f;
//             }
//         }
//     }

//     public void restoreHunger(float hungerAmount)
//     {
//         if (playerHunger < hungerImage.Length)
//         {
//             playerHunger += hungerAmount;
//         }

//         if(playerHunger > hungerImage.Length)
//         {
//             playerHunger = hungerImage.Length;
//         }


//         hungerFill();
//     }

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
