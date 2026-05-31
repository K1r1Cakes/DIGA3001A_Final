using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public float despawnTime = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    
}
