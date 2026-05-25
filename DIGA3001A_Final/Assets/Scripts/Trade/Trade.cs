using UnityEngine;

public class Trade : MonoBehaviour
{
    public ShopItem shopItem;
   public InventoryController inventory;
   public PlayerLevel playerLevel;

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
