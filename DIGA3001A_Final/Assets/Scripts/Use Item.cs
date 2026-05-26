using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    
    public Playerthirst thirst;
    public Playerhunger hunger;
    public Playerhealth health;
    public InventoryController inventory;
    public PlayerShoot shoot;
    public Item currentItem;

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
            //inventory.RemoveItem("Water");
        }

        if (currentItem.itemName == "Food")
        {
            Debug.Log("Eat food");
            hunger.fillHunger(10);
            //inventory.RemoveItem("Food");
        }

        if (currentItem.itemName == "Health")
        {
            Debug.Log("Heal up");
            health.fillHealth(10);
            //inventory.RemoveItem("Health");
        }

        if (currentItem.itemName == "Bullet")
        {
            Debug.Log("Bullets added");
            shoot.bulletAmount += 5;
           // inventory.RemoveItem("Bullet");
        }
        
        inventory.RemoveItemFromSlot(currentItem.parentSlot);
    }
}
