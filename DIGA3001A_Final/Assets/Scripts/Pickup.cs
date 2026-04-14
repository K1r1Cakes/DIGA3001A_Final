using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public bool isMedkit = false;
    public string tagName;
    public GameObject panel;
    public Playerhealth playerhealth;
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

            if (playerhealth != null)
            {
                playerhealth.heartHeal();
            }
           // gameObject.SetActive(false);
        }
    }

    public void getTagName()
    {
        tagName = gameObject.tag;
        Debug.Log("Picked up "+tagName);
    }

}
