using UnityEngine;
using UnityEngine.InputSystem;

public class OpenCrafting : MonoBehaviour
{
    public GameObject panel;
    private bool inRange = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enters range");
            inRange = true;
        }
    }

    public void onOpenCraft(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (panel != null && inRange == true)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);


            PauseController.SetPause(!isActive);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is out of Range");
            inRange = false;
        }
    }
}
