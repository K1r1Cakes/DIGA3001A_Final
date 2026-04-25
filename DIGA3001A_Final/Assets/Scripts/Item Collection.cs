using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemCollection : MonoBehaviour
{
    private bool isNear = false;
    public GameObject itemPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCollect(InputAction.CallbackContext context)
    {
        //Pickup

        if (isNear == true)
        {
            itemPrefab.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Medkit"))
        {
            isNear = true;
        }
    }
}
