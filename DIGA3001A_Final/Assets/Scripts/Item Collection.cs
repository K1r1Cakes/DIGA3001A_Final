using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemCollection : MonoBehaviour
{
    private bool isNear = false;
    private GameObject itemPrefab;
    private InventoryController inventoryController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCollect(InputAction.CallbackContext context)
    {
       if (isNear == true)
        {
            inventoryController.AddItem(itemPrefab);
            Destroy(itemPrefab);
            isNear = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Item"))
        {

           itemPrefab = collide.gameObject;
           isNear = true;
           
        }
    }
}
