using UnityEngine;

public class Stick : MonoBehaviour
{
    public int stickLifeSpan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stickLifeSpan = Random.Range(2,6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
