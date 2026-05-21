using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    
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
        if (!context.started) return;

         if (PauseController.isGamePaused)
         {
            return;
         }
        
        Instantiate(bulletPrefab, transform.position, transform.rotation);
       // audioSource.Play();
    }
}
