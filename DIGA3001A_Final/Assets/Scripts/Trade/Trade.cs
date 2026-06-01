using UnityEngine;
using TMPro;

public class Trade : MonoBehaviour
{
    public ShopItem shopItem;
   public InventoryController inventory;
   public PlayerLevel playerLevel;
   public TextMeshProUGUI infoText;
    public WarningMessagePanel warn;
    private bool warningShown = false;

    public void OnBuyItem()
    {
        if(playerLevel.levelAmount < shopItem.itemCost)
        {
            infoText.text = "Not enough Orbs";
            return;
        }
        else
        {
            if (inventory.isInventoryFull())
            {
                warn.showWarning("Inventory Full", 2f);
                return;
            }
            
            inventory.AddItem(shopItem.itemPrefab);
            playerLevel.loseLevel(shopItem.itemCost);
        }

        if (shopItem.itemName == "Stick")
        {
            infoText.text = "Place the stick in the hotbar and select it by using the corresponding number.";
        }

        if (shopItem.itemName == "Water")
        {
            infoText.text = "Use this item to add +10 thirst.";
        }

        if (shopItem.itemName == "Medkit")
        {
            infoText.text = "Use this item to +10 health";
        }

        if (shopItem.itemName == "Coconut x 5")
        {
            infoText.text = "Use this item to +5 coconuts.";
        }

    }
}
