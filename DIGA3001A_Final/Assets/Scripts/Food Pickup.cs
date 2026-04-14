using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public float hungerAmount = 0.5f;
    public Playerhunger playerhunger;
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
            playerhunger.restoreHunger(hungerAmount);
            Debug.Log("Food picked up");
        }
    }
}
