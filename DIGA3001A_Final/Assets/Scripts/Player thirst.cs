using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerthirst : MonoBehaviour
{
    public float playerThirst = 3f;
    public float globalThirstTimer;
    public float thirstTimer = 2f;
    public Image[] waterImage;
    //public Playerhealth playerhealth;
    public TextMeshProUGUI textThirst;
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
            if (playerThirst > 0)
            {
              loseThirst();
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

    void loseThirst()
    {
        playerThirst -= 0.5f;

        if (playerThirst <= 1)
        {
            textThirst.text = "You are dehydrated! Drink water now";
            isThirsty = true;
        }
        else
        {
            isThirsty = false;
        }

        if (playerThirst < 0)
        {
            playerThirst = 0;
        }

        thisrtFill();
    }

    void thisrtFill()
    {
        for(int i = 0; i < waterImage.Length; i++)
        {
            float remainingThirst = playerThirst - i;

            if (remainingThirst >= 1)
            {
                waterImage[i].fillAmount = 1f;
            }
            else if(remainingThirst > 0)
            {
                waterImage[i].fillAmount = 0.5f;
            }
            else
            {
                waterImage[i].fillAmount =0f;
            }
        }
    }

    public void restoreThirst(float thirstAmount)
    {
        if (playerThirst < waterImage.Length)
        {
            playerThirst += thirstAmount;
        }

        if (playerThirst > waterImage.Length)
        {
            playerThirst = waterImage.Length;
        }

        thisrtFill();

    }
}
