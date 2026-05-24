using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerSword : MonoBehaviour
{
    public GameObject swordRange;
    public bool isSwinging = false; 
    public float swingTime = 0.2f;
    public HotBarController hotBarController;
    
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

        swordRange.SetActive(true);

        yield return new WaitForSeconds(swingTime);

        swordRange.SetActive(false);

        isSwinging = false;
    }
}
