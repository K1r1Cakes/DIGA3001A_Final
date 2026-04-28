using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Item currentItem;

   
    public Playerthirst thirst;
    public Playerhunger hunger;
    public Playerhealth health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
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
        }

        if (currentItem.itemName == "Food")
        {
            Debug.Log("Eat food");
            hunger.fillHunger(10);
        }

        if (currentItem.itemName == "Health")
        {
            Debug.Log("Heal up");
            health.fillHealth(10);
        }
    }
}
