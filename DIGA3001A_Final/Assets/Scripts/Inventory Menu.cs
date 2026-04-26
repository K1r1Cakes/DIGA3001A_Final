using UnityEditor.U2D.Tooling.Analyzer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpenInventory(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);


            PauseController.SetPause(!isActive);
        }
    }
}
