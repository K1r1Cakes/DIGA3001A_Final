using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public int bulletAmount = 10;
    public TextMeshProUGUI bulletAmountText;
    public HotBarController hotBarController;
    public WarningMessagePanel warn;
    private bool warningShown = false;
    
    //shoot form
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletAmountText.text = bulletAmount.ToString();
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

        if (hotBarController.selectedItem.itemName != "Slingshot")
        {
            return;
        }

         if (PauseController.isGamePaused)
         {
            return;
         }
        
        
        if (bulletAmount <= 0)
        {
             warn.showWarning("No buts, no cuts, NO COCONUTS", 1f);
            bulletAmount = 0;
            return;
        }

            SoundEffectManager.Play("Shoot");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletAmount -= 1;
            Debug.Log("Shoot"); 
        
        
       // audioSource.Play();
    }
}
