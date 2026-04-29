using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Craftitem : MonoBehaviour
{
    public GameObject completedItem;
    public Item itemsList;
    public float itemsNeeded = 3;
    public InventoryController inventoryController;
    public TextMeshProUGUI amountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void unlockShelter()
    {
        if (inventoryController.hasItem(itemsList, itemsNeeded))
        {
            Debug.Log("Got shelter");
            completedItem.SetActive(true);
            UpdateUI();
        }
        else
        {
            Debug.Log("Need more wood");
        }
    }

    void UpdateUI()
    {
        int currentAmount = inventoryController.GetItemCount(itemsList);
        amountText.text = currentAmount + " / " + itemsNeeded;
    }
}
