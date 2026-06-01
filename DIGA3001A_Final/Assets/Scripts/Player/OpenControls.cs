using UnityEngine;
using UnityEngine.InputSystem;

public class OpenControls : MonoBehaviour
{
    public GameObject controlMenu;

    public void onCOntrolMenu(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (controlMenu != null)
        {
            bool isActive = controlMenu.activeSelf;
            controlMenu.SetActive(!isActive);


            PauseController.SetPause(!isActive);
        }
    }

}
