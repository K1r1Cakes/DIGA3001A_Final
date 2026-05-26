using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTradeMenu : MonoBehaviour
{
    public GameObject tradePanel;
    public bool inRange = false;

    //Create player input to toggle menu

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Trade"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.CompareTag("Trade"))
        {
            inRange = false;
        }
    }

    public void onTradeMenu(InputAction.CallbackContext context)
    {
            if (!context.performed) return;

        if (tradePanel != null && inRange == true)
        {
            bool isActive = tradePanel.activeSelf;
            tradePanel.SetActive(!isActive);


            PauseController.SetPause(!isActive);
        }
    }
}
