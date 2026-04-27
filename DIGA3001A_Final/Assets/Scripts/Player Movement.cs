using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private float moveSpeed = 4f;
   private Rigidbody2D rb;
   private Vector2 moveInput;
   public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
        rb.linearVelocity = moveInput * moveSpeed;
        RotateInDirectionOfInput();
    }

   public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void RotateInDirectionOfInput()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }
}
