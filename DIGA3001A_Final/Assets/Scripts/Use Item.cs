using TMPro;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    
    public Playerthirst thirst;
    public Playerhunger hunger;
    public Playerhealth health;
    public InventoryController inventory;
    public PlayerShoot shoot;
    public Item currentItem;
    public TextMeshProUGUI itemStatusText;
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

        if (currentItem.itemName == "Bullet")
        {
            Debug.Log("Bullets added");
            shoot.bulletAmount += 5;
            itemStatusText.text = "Bullets added";
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

        if (isHotBar == false)
        {
            inventory.RemoveItemFromSlot(currentItem.parentSlot);
        }
       
    }
}
