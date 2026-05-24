using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public HotBarController hotBarController;
    
    //shoot form
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Input detected");

        if (!context.performed) return;
        Debug.Log("Performed");

        if (hotBarController.selectedItem == null)
        {
            Debug.Log("Gun not selected");
            return;
        }

        if (hotBarController.selectedItem.itemName != "Gun")
        {
            return;
        }

         if (PauseController.isGamePaused)
         {
            return;
         }
        
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Debug.Log("Shoot");
       // audioSource.Play();
    }
}
