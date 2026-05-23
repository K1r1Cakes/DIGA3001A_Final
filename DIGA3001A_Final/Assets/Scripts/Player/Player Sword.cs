using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSword : MonoBehaviour
{
    public GameObject swordRange;
    public Transform swordPoint;
    public bool isSwinging = false; 
    
    public void OnSwing(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            isSwinging = false;
            return;
        }
        else
        {
            isSwinging = true;
        }
    }
}
