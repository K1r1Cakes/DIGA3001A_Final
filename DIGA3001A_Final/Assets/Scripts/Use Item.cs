using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            thirst.fillThirst(10);
            itemStatusText.text = "Water consumed";
            isHotBar = false;
        }

        if (currentItem.itemName == "Food")
        {
            Debug.Log("Eat food");
            hunger.fillHunger(10);
            itemStatusText.text = "Food consumed";
            isHotBar = false;
        }

        if (currentItem.itemName == "Health")
        {
            Debug.Log("Heal up");
            health.fillHealth(10);
            itemStatusText.text = "Medkit consumed";
            isHotBar = false;
        }

        if (currentItem.itemName == "Coconut")
        {
            Debug.Log("Bullets added");
            shoot.bulletAmount += 5;
            itemStatusText.text = "Coconut added";
            isHotBar = false;
        }

        if (currentItem.itemName == "Gun")
        {
            itemStatusText.text = "Put in hotbar to use";
            isHotBar = true;
        }

        if (currentItem.itemName == "Stick")
        {
            itemStatusText.text = "Put in hotbar to use";
            isHotBar = true;
        }

        if (currentItem.itemName == "Micro Controller")
        {
            itemStatusText.text = "Added to radio";
            radioMaker.isMicro = true;
            radioMaker.unlockForest();
            isHotBar = false;
        }

        if (currentItem.itemName == "Controls")
        {
            itemStatusText.text = "Added to radio";
            radioMaker.isControl = true;
            radioMaker.unlockDesert();
            isHotBar = false;
        }

        if (currentItem.itemName == "Antenna")
        {
            itemStatusText.text = "Added to radio";
            radioMaker.isAntenna = true;
            isHotBar = false;
        }

         if (currentItem.itemName == "Radio")
        {
            itemStatusText.text = "Radio made";
            isHotBar = false;
            //Calls end game
        }

        if (isHotBar == false)
        {
            inventory.RemoveItemFromSlot(currentItem.parentSlot);
            useButton.interactable = false;
        }
       
    }
}
