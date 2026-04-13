using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public bool isMedkit = false;
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            getTagName();
            togglePanel();
            gameObject.SetActive(false);
        }
    }

    public void getTagName()
    {
        string tagName = gameObject.tag;
        Debug.Log("Picked up "+tagName);
    }

    private void togglePanel()
    {
        panel.SetActive(true);
    }
}
