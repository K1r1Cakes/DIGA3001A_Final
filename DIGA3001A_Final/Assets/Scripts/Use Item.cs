using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Item item;
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
        
        
        if(item.itemName == "Water")
        {
            Debug.Log("Drink water");
        }
    }
}
