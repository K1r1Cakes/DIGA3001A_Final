using UnityEngine;

public class Water_Pickup : MonoBehaviour
{
    public float thirstAmount = 0.5f;
    public Playerthirst playerthirst;
    public AudioSource audioSource;
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
            Debug.Log("Water picked up");
            audioSource.Play();
            playerthirst.restoreThirst(thirstAmount);
        }
    }
}
