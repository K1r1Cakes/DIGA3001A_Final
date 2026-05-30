using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateAlter1 : MonoBehaviour
{
    public GameObject alterPanel;
    public bool inRange = false;

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Alter"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.CompareTag("Alter"))
        {
            inRange = false;
        }
    }

    public void onAlterMenu(InputAction.CallbackContext context)
    {
            if (!context.performed) return;

        if (alterPanel != null && inRange == true)
        {
            bool isActive = alterPanel.activeSelf;
            alterPanel.SetActive(!isActive);


            PauseController.SetPause(!isActive);
        }
    }
}
