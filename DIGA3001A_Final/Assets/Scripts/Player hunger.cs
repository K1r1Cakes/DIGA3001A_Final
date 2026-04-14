using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhunger : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float hungerTimer = 5f;
    public float globalTimer;
    public float playerHunger = 3f;
    public Image[] hungerImage;
    public Playerhealth playerhealth;
    public TextMeshProUGUI hungerText;
    public bool isHungry = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTimer = hungerTimer;
    }

    // Update is called once per frame
    void Update()
    {
        globalTimer -= Time.deltaTime;

        if(globalTimer <= 0)
        {
            if (playerHunger > 0)
            {
              loseHunger();
              globalTimer = hungerTimer;  
            }
            else
            {
             Debug.Log("Player starved to death");
             playerhealth.playerDamage();
            }
            globalTimer = hungerTimer;
        }
        
        
    }

    void loseHunger()
    {
        playerHunger -= 0.5f;

        if (playerHunger <= 1)
        {
            hungerText.text = "You are starving. Eat now!";
            isHungry = true;
        }
        else
        {
            isHungry = false;
        }

        if (playerHunger < 0)
        {
            playerHunger = 0;
        }

        hungerFill();
    }
    void hungerFill()
    {
        Debug.Log("Half hunger bar");

        for(int i = 0; i < hungerImage.Length; i++)
        {
            float remainingHunger = playerHunger - i;

            if (remainingHunger >= 1)
            {
                hungerImage[i].fillAmount = 1f;
            }
            else if(remainingHunger > 0)
            {
                hungerImage[i].fillAmount = 0.5f;
            }
            else
            {
                hungerImage[i].fillAmount =0f;
            }
        }
    }

    public void restoreHunger(float hungerAmount)
    {
        if (playerHunger < hungerImage.Length)
        {
            playerHunger += hungerAmount;
        }

        if(playerHunger > hungerImage.Length)
        {
            playerHunger = hungerImage.Length;
        }


        hungerFill();
    }
}
