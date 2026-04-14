using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Playerthirst thirst;
    public Playerhealth health;
    public Playerhunger hunger;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        if (thirst.isThirsty || health.isHealth || hunger.isHungry)
        {
            moveSpeed = 2f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }

     public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

}