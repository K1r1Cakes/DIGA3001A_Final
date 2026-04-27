using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InventoryController inventoryController;
    private HotBarController hotBarController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Define save location
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        inventoryController = FindAnyObjectByType<InventoryController>();
        hotBarController = FindAnyObjectByType<HotBarController>();
        LoadGame();
    }

   public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = inventoryController.GetInventoryItems(),
            hotbarSaveData = hotBarController.GetHotbarItems()
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            inventoryController.SetInventoryItems(saveData.inventorySaveData);
            hotBarController.SetHotbarItems(saveData.hotbarSaveData);
        }
        else
        {
            SaveGame();
        }
    }
}
