using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerSword : MonoBehaviour
{
    public GameObject swordRange;
    public bool isSwinging = false; 
    public float swingTime = 0.2f;
    //public Stick stick;
    public HotBarController hotBarController;
    public InventoryController inventory;
    
    public void OnSwing(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {

            return;
        }

          if (hotBarController.selectedItem == null)
        {
            Debug.Log("Gun not selected");
            return;
        }

        if (hotBarController.selectedItem.itemName != "Stick")
        {
            return;
        }

        // if (stick.stickLifeSpan <= 0)
        // {
        //     //inventory.RemoveItem(hotBarController.selectedItemObject);
        //     inventory.RemoveItemFromSlot(hotBarController.selectedItem.parentSlot);
        //     return;
        // }

        if (context.performed)
        {
            StartCoroutine(swingSword());
        }
        

        if (PauseController.isGamePaused)
         {
            return;
         }
    }

    private IEnumerator swingSword()
    {
        isSwinging = true;
        SoundEffectManager.Play("Swoosh");
        swordRange.SetActive(true);

        yield return new WaitForSeconds(swingTime);

        Stick currentStick = hotBarController.selectedItem.GetComponent<Stick>();

        currentStick.stickLifeSpan -= 1;

        if (currentStick.stickLifeSpan <= 0)
        {
            SoundEffectManager.Play("Break");
            inventory.RemoveItemFromSlot(hotBarController.selectedItem.parentSlot);
        }
        
        swordRange.SetActive(false);

        isSwinging = false;
    }
}
