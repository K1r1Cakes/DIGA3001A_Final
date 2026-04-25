using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerthirst : MonoBehaviour
{
    public float thirstAmount = 100f;
    public float thirstDamage = 10f;
    public float globalThirstTimer;
    public float thirstTimer = 2f;
    public Image thirstBar;
    //public Playerhealth playerhealth;
    
    public bool isThirsty = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalThirstTimer = thirstTimer;
    }

    // Update is called once per frame
    void Update()
    {
        globalThirstTimer -= Time.deltaTime;

        if(globalThirstTimer <= 0)
        {
            if (thirstAmount > 0)
            {
              loseThirst(thirstDamage);
              globalThirstTimer = thirstTimer;  
            }
            else
            {
             Debug.Log("Player is thirsty!");
            // playerhealth.playerDamage();
            }
            globalThirstTimer = thirstTimer;
        }
    }

    // void loseThirst()
    // {
    //     playerThirst -= 0.5f;

    //     if (playerThirst <= 1)
    //     {
    //        // textThirst.text = "You are dehydrated! Drink water now";
    //         isThirsty = true;
    //     }
    //     else
    //     {
    //         isThirsty = false;
    //     }

    //     if (playerThirst < 0)
    //     {
    //         playerThirst = 0;
    //     }

    //     //thisrtFill();
    // }

    // void thisrtFill()
    // {
    //     for(int i = 0; i < waterImage.Length; i++)
    //     {
    //         float remainingThirst = playerThirst - i;

    //         if (remainingThirst >= 1)
    //         {
    //             waterImage[i].fillAmount = 1f;
    //         }
    //         else if(remainingThirst > 0)
    //         {
    //             waterImage[i].fillAmount = 0.5f;
    //         }
    //         else
    //         {
    //             waterImage[i].fillAmount =0f;
    //         }
    //     }
    // }

    // public void restoreThirst(float thirstAmount)
    // {
    //     if (playerThirst < waterImage.Length)
    //     {
    //         playerThirst += thirstAmount;
    //     }

    //     if (playerThirst > waterImage.Length)
    //     {
    //         playerThirst = waterImage.Length;
    //     }

    //     thisrtFill();

    // }

    public void loseThirst(float thirst)
    {
        thirstAmount -= thirst;
        thirstBar.fillAmount = thirstAmount/100f;
    }
}
