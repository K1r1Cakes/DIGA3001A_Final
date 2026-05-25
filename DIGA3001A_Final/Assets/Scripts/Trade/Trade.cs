using UnityEngine;

public class Trade : MonoBehaviour
{
    public ShopItem shopItem;
   public InventoryController inventory;
   public PlayerLevel playerLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuyItem()
    {
        if(playerLevel.levelAmount < shopItem.itemCost)
        {
            return;
        }
        else
        {
            inventory.AddItem(shopItem.itemPrefab);
            playerLevel.levelAmount -= shopItem.itemCost;
        }


    }
}
