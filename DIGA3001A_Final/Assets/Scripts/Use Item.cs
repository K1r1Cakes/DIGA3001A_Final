using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UseItem : MonoBehaviour
{
    
    public Playerthirst thirst;
    public Playerhunger hunger;
    public Playerhealth health;
    public InventoryController inventory;
    public PlayerShoot shoot;
    public Item currentItem;
    public RadioMaker radioMaker;
    public TextMeshProUGUI itemStatusText;
    public Button useButton;
    private bool isHotBar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      currentItem = GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUseItem()
    {
        
        if(currentItem.itemName == "Water")
        {
            Debug.Log("Drink water");
            SoundEffectManager.Play("Drink");
            thirst.fillThirst(10);
            itemStatusText.text = "Water consumed";
            isHotBar = false;
        }

        if (currentItem.itemName == "Cherry")
        {
            Debug.Log("Eat food");

            isHotBar = false;
            Debug.Log("Eat food audio");
            SoundEffectManager.Play("Eat");
            hunger.fillHunger(10);
            itemStatusText.text = "Food consumed";
            
        }

        if (currentItem.itemName == "Health")
        {
            Debug.Log("Heal up");
            SoundEffectManager.Play("Heal");
            health.fillHealth(10);
            itemStatusText.text = "Medkit consumed";
            isHotBar = false;
        }

        if (currentItem.itemName == "Coconut")
        {
            Debug.Log("Bullets added");
            SoundEffectManager.Play("itemUse");
            shoot.bulletAmount += 5;
            itemStatusText.text = "Coconut added";
            isHotBar = false;
        }

        if (currentItem.itemName == "Slingshot")
        {
            SoundEffectManager.Play("itemUse");
            itemStatusText.text = "Put in hotbar to use";
            isHotBar = true;
        }

        if (currentItem.itemName == "Stick")
        {
            SoundEffectManager.Play("itemUse");
            itemStatusText.text = "Put in hotbar to use";
            isHotBar = true;
        }

        if (currentItem.itemName == "Micro Controller")
        {
            SoundEffectManager.Play("radioUse");
            itemStatusText.text = "Added to radio, Forest unlocked";
            radioMaker.isMicro = true;
            radioMaker.unlockForest();
            isHotBar = false;
        }

        if (currentItem.itemName == "Controls")
        {
            SoundEffectManager.Play("radioUse");
            itemStatusText.text = "Added to radio, Desert unlocked";
            radioMaker.isControl = true;
            radioMaker.unlockDesert();
            isHotBar = false;
        }

        if (currentItem.itemName == "Antenna")
        {
            SoundEffectManager.Play("radioUse");
            itemStatusText.text = "Added to radio, radio made";
            radioMaker.isAntenna = true;
            isHotBar = false;
        }

         if (currentItem.itemName == "Radio")
        {
            itemStatusText.text = "Calling..";
            isHotBar = false;
            SceneManager.LoadScene("End");
            //Calls end game
        }

        if (isHotBar == false)
        {
            inventory.RemoveItemFromSlot(currentItem.parentSlot);
            useButton.interactable = false;
        }
       
    }
}
